using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels;
using ServiceDeskSVC.Domain.Entities.ViewModels.UserRefresh;

namespace ServiceDeskSVC.Managers.UserRefresh
{
    public interface IUserRefreshManager
    {
        UserRefreshReturn RunRefreshForAllUsers();
    }
}
