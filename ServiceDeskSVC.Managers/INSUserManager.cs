using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers
{
    public interface INSUserManager
    {
        List<NSUser_vm> GetUserBySearch(string searchTerm, int numResults);

        List<NSUser_vm> GetAllUsers();

        NSUser_vm GetUserByUserName(string userName);

        NSUser_vm GetUserBySID(string sid);
    }
}
