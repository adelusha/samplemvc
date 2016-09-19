using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.DataAccess.UserRefresh;
using ServiceDeskSVC.Domain.Entities.ViewModels.UserRefresh;
using ServiceDeskSVC.Managers.UserRefresh;

namespace ServiceDeskSVC.Managers.Managers.UserRefresh
{
    public class UserRefreshManager : IUserRefreshManager
    {
        private readonly IUserRefreshRepository _userRefreshRepository;
        private readonly INSLocationManager _nsLocationManager;
        private readonly IDepartmentManager _departmentManager;
        private readonly ILogger _logger;

        public UserRefreshManager(IUserRefreshRepository userRefreshRepository, INSLocationManager nsLocationManager,
                                  IDepartmentManager departmentManager, ILogger logger)
        {
            _userRefreshRepository = userRefreshRepository;
            _nsLocationManager = nsLocationManager;
            _departmentManager = departmentManager;
            _logger = logger;
        }


        public UserRefreshReturn RunRefreshForAllUsers()
        {
            var refresh = new UserRefreshReturn
            {
                success = true
            };

            var data = GetAllUserData();
            var departments = getUniqueDepartments(data);
            var deptsRefreshed = RefreshDepartments(departments);

            if (!deptsRefreshed)
            {
                refresh.success = false;
                refresh.errorMessage = "Departments Failed";
                return refresh;
            }

            //REFRESH LOCATIONS
            var locations = getUniqueLocations(data);
            var locsRefreshed = RefreshLocations(locations);

            if (!locsRefreshed)
            {
                refresh.success = false;
                refresh.errorMessage = "Locations Failed";
                return refresh;
            }

            data = PopulateLocationIds(data);
            data = PopulateDepartmentIds(data);

            List<ServiceDesk_Users> EFData = data.Select(MapRefreshModelToEFModel).ToList();

            var usersRefreshed = RefreshUserData(EFData);

            if (!usersRefreshed)
            {
                refresh.success = false;
                refresh.errorMessage = "Users Failed";
                return refresh;
            }

            return refresh;
        }

        private bool RefreshDepartments(List<Department> depts)
        {
            return _userRefreshRepository.RunRefreshForAllDepartments(depts);
        }

        private bool RefreshUserData(List<ServiceDesk_Users> EFUsers)
        {
            return _userRefreshRepository.RunRefreshForAllUsers(EFUsers);
        }

        private bool RefreshLocations(List<NSLocation> locs)
        {
            return _userRefreshRepository.RunRefreshForAllLocations(locs);
        }


        private ServiceDesk_Users MapRefreshModelToEFModel(UserRefreshModel refreshModel)
        {
            return new ServiceDesk_Users
            {
                SID = refreshModel.SID,
                UserName = refreshModel.UserName,
                FirstName = refreshModel.FirstName,
                LastName = refreshModel.LastName,
                EMail = refreshModel.EMail,
                LocationId = refreshModel.LocationId ?? 0,
                DepartmentId = refreshModel.DepartmentId ?? 0
            };
        }

        private List<UserRefreshModel> PopulateDepartmentIds(List<UserRefreshModel> model)
        {
            var departments = _departmentManager.GetAllDepartments();

            foreach (var m in model)
            {
                m.DepartmentId = departments.Where(d => d.DepartmentName == m.Department).Select(di => di.Id).FirstOrDefault();
            }

            return model;
        }

        private List<UserRefreshModel> PopulateLocationIds(List<UserRefreshModel> model)
        {
            var locations = _nsLocationManager.GetAllLocations();

            foreach (var l in model)
            {
                l.LocationId = locations.Where(lo => lo.LocationCity == l.Location).Select(li => li.Id).FirstOrDefault();
                if (l.LocationId.GetType() != typeof(int))
                {
                    l.LocationId = 0;
                }
            }


            return model;
        } 

        private List<UserRefreshModel> GetAllUserData()
        {
            List<UserRefreshModel> model = new List<UserRefreshModel>();

            using (var context = new PrincipalContext(ContextType.Domain, "safety.northernsafety.com"))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        UserRefreshModel singleUser = new UserRefreshModel();

                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        if (de != null && de.Properties["givenName"].Value != null && de.Properties["physicalDeliveryOfficeName"].Value != null && de.Properties["department"].Value != null)
                        {
                            singleUser.FirstName = de.Properties["givenName"].Value.ToString();
                            singleUser.LastName = de.Properties["sn"].Value != null ? de.Properties["sn"].Value.ToString() : "";
                            singleUser.EMail = de.Properties["mail"].Value != null ? de.Properties["mail"].Value.ToString() : "";
                            singleUser.UserName = de.Properties["sAMAccountName"].Value != null ? de.Properties["sAMAccountName"].Value.ToString() : "";
                            singleUser.Location = de.Properties["physicalDeliveryOfficeName"].Value.ToString();
                            singleUser.Department = de.Properties["department"].Value.ToString();
                            var sidBytes = (byte[])de.Properties["objectSid"].Value;
                            SecurityIdentifier sid = new SecurityIdentifier(sidBytes, 0);
                            singleUser.SID = sid.ToString();

                            model.Add(singleUser);
                        }
                    }

                }
            }

            return model;
        }

        private List<Department> getUniqueDepartments(List<UserRefreshModel> model)
        {
            List<Department> departments = model.Select(d => new Department { DepartmentName = d.Department }).ToList()
                .GroupBy(g => g.DepartmentName).Select(dpt => dpt.First()).ToList();

               
            return departments;
        }

        private List<NSLocation> getUniqueLocations(List<UserRefreshModel> model)
        {
            List<NSLocation> locations =
                model.Select(l => new NSLocation { LocationCity = l.Location, LocationState = " ", LocationZip = 0}).ToList()
                    .GroupBy(g => g.LocationCity).Select(loc => loc.First()).ToList();

            return locations;
        }
    }
}
