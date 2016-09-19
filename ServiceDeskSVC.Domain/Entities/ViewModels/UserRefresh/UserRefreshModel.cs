using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.UserRefresh
{
    public class UserRefreshModel
    {
        public int Id { get; set; }
        public string SID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Department { get; set; }
        public int? DepartmentId { get; set; }
        public string Location { get; set; }
        public int? LocationId { get; set; }
    }

    public class UserRefreshReturn
    {
        public bool success { get; set; }
        public string errorMessage { get; set; }
    }

    public class LocationRefresh
    {
        public string locationCity { get; set; }
    }
}
