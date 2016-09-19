using System;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tasks
{
    public class HelpDesk_Tasks_vm
    {
    public int Id { get; set; }
    public int TicketID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int StatusID { get; set; }
    public Nullable<System.DateTime> CreatedDateTime { get; set; }
    public Nullable<System.DateTime> StatusChangedDateTime { get; set; }
    public string AssignedToUserName { get; set; }
    public virtual Task_User ServiceDesk_Users_AssignedTo { get; set; }
      
    }

    public class Task_User
        {
        public string SID { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }
        }

}
