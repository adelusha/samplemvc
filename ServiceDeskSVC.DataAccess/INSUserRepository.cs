using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
    {
    public interface INSUserRepository
        {
        List<ServiceDesk_Users> GetUserFromSearch(string search, int numResults);

        List<ServiceDesk_Users> GetAllUsers();

        ServiceDesk_Users GetUserByUserName(string userName);

        ServiceDesk_Users GetUserBySID(string sid);
        }
    }
