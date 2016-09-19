using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class HelpDesk_Tasks
    {
        public int Id { get; set; }
        public int TicketID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusID { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<System.DateTime> StatusChangedDateTime { get; set; }
        public int AssignedTo { get; set; }
        public string RelatedTaskIds { get; set; }
        public virtual HelpDesk_TaskStatus HelpDesk_TaskStatus { get; set; }
        public virtual HelpDesk_Tickets HelpDesk_Tickets { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users { get; set; }
    }
}
