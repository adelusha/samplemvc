using System;
using ServiceDeskSVC.Domain.Utilities;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets
{
    public class HelpDesk_Tickets_View_vm
    {
        public int Id { get; set; }

        public int TicketNumber { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Requestor { get; set; }

        public string Department { get; set; }

        public string Location { get; set; }

        public DateTime? RequestDateTime { get; set; }

        public DateTime? RequestedDueDate { get; set; }

        public string TicketCategory { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public string AssignedTo { get; set; }

        public string Vendor { get; set; }

        public string VendorTicket { get; set; }

        public string TicketType { get; set; }

        public bool NeedsApproval { get; set; }

        public string ApprovedBy { get; set; }

        public DateTime? ApprovedOn { get; set; }
    }
}
