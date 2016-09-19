using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class HelpDesk_Tickets
    {
        public HelpDesk_Tickets()
        {
            this.HelpDesk_Tasks = new List<HelpDesk_Tasks>();
            this.HelpDesk_TicketAttachments = new List<HelpDesk_TicketAttachments>();
            this.HelpDesk_TicketComments = new List<HelpDesk_TicketComments>();
            this.HelpDesk_TicketDocuments = new List<HelpDesk_TicketDocuments>();
        }

        public int Id { get; set; }
        public int TicketNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Requestor { get; set; }
        public int? DepartmentID { get; set; }
        public int? LocationID { get; set; }
        public Nullable<System.DateTime> RequestDateTime { get; set; }
        public Nullable<System.DateTime> RequestedDueDate { get; set; }
        public int TicketCategoryID { get; set; }
        public byte PriorityCode { get; set; }
        public int StatusID { get; set; }
        public int AssignedTo { get; set; }
        public Nullable<int> VendorID { get; set; }
        public string VendorTicket { get; set; }
        public int TicketTypeID { get; set; }
        public bool NeedsApproval { get; set; }
        public Nullable<int> ApprovedBy { get; set; }
        public Nullable<System.DateTime> ApprovedOn { get; set; }
        public virtual AssetManager_Companies AssetManager_Companies { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<HelpDesk_Tasks> HelpDesk_Tasks { get; set; }
        public virtual ICollection<HelpDesk_TicketAttachments> HelpDesk_TicketAttachments { get; set; }
        public virtual HelpDesk_TicketCategory HelpDesk_TicketCategory { get; set; }
        public virtual ICollection<HelpDesk_TicketComments> HelpDesk_TicketComments { get; set; }
        public virtual ICollection<HelpDesk_TicketDocuments> HelpDesk_TicketDocuments { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users1 { get; set; }
        public virtual NSLocation NSLocation { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users2 { get; set; }
        public virtual HelpDesk_TicketStatus HelpDesk_TicketStatus { get; set; }
        public virtual HelpDesk_TicketType HelpDesk_TicketType { get; set; }
    }
}
