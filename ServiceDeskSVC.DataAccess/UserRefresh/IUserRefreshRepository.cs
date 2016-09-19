using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.UserRefresh
{
    public interface IUserRefreshRepository
    {
        bool RunRefreshForAllUsers(List<ServiceDesk_Users> users);

        bool RunRefreshForAllDepartments(List<Department> departments);

        bool RunRefreshForAllLocations(List<NSLocation> locations);
    }
}
