using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class NSUserManager:INSUserManager
        {
        private readonly INSUserRepository _nsUserRepository;
        private readonly ILogger _logger;

        public NSUserManager(INSUserRepository nsUserRepository, ILogger logger)
            {
            _nsUserRepository = nsUserRepository;
            _logger = logger;
            }

        public List<NSUser_vm> GetUserBySearch(string searchTerm, int numResults)
            {
            var results = _nsUserRepository.GetUserFromSearch(searchTerm, numResults);
            return results.Select(mapEntityToViewModelUser).OrderBy(s => s.FirstName).ThenBy(s2 => s2.LastName).ToList();
            }

        public List<NSUser_vm> GetAllUsers()
            {
            var users = _nsUserRepository.GetAllUsers();
            return users.Select(mapEntityToViewModelUser).ToList();
            }

        public NSUser_vm GetUserByUserName(string userName)
            {
            if(string.IsNullOrEmpty(userName))
                {
                throw new ArgumentNullException(userName);
                }

            var user = _nsUserRepository.GetUserByUserName(userName);
            return mapEntityToViewModelUser(user);
            }

        public NSUser_vm GetUserBySID(string sid)
            {
            if(string.IsNullOrEmpty(sid))
                {
                throw new ArgumentNullException(sid);
                }

            var user = _nsUserRepository.GetUserBySID(sid);
            return mapEntityToViewModelUser(user);
            }

        private NSUser_vm mapEntityToViewModelUser(ServiceDesk_Users EFUser)
            {
            return new NSUser_vm
            {
                Id = EFUser.Id,
                SID = EFUser.SID,
                UserName = EFUser.UserName,
                FirstName = EFUser.FirstName,
                LastName = EFUser.LastName,
                EMail = EFUser.EMail,
                Department = EFUser.Department.DepartmentName,
                Location = EFUser.NSLocation.LocationCity
            };
            }


        }
    }
