using System;
using System.Security.Policy;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets
{
    public class HelpDesk_Tickets_vm
    {
    public int TicketNumber { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string RequestorUserName { get; set; }
    public int? DepartmentID { get; set; }
    public int? LocationID { get; set; }
    public DateTime? RequestDateTime { get; set; }
    public DateTime? RequestedDueDate { get; set; }
    public int TicketCategoryID { get; set; }
    public byte PriorityCode { get; set; }
    public int StatusID { get; set; }
    public string AssignedToUserName { get; set; }
    public int? VendorID { get; set; }
    public string VendorTicket { get; set; }
    public int TicketTypeID { get; set; }
    public bool NeedsApproval { get; set; }
    public string ApprovedByUserName { get; set; }
    public DateTime? ApprovedOn { get; set; }
    public virtual Ticket_User ApprovedByUser { get; set; }
    public virtual Ticket_User AssignedToUser { get; set; }
    public virtual Ticket_User RequestorUser { get; set; }
    }

    public class Ticket_User
        {
        public string SID { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string UserLocation { get; set; }

        public string UserDepartment { get; set; }
        }
}
