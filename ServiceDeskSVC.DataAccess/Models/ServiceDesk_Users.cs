using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class ServiceDesk_Users
    {
        public ServiceDesk_Users()
        {
            this.AssetManager_AssetAttachments = new List<AssetManager_AssetAttachments>();
            this.AssetManager_AssetAttachments1 = new List<AssetManager_AssetAttachments>();
            this.AssetManager_AssetStatus = new List<AssetManager_AssetStatus>();
            this.AssetManager_AssetStatus1 = new List<AssetManager_AssetStatus>();
            this.AssetManager_Hardware = new List<AssetManager_Hardware>();
            this.AssetManager_Hardware1 = new List<AssetManager_Hardware>();
            this.AssetManager_Hardware2 = new List<AssetManager_Hardware>();
            this.AssetManager_Hardware3 = new List<AssetManager_Hardware>();
            this.AssetManager_Software = new List<AssetManager_Software>();
            this.AssetManager_Software1 = new List<AssetManager_Software>();
            this.AssetManager_Software2 = new List<AssetManager_Software>();
            this.AssetManager_Software3 = new List<AssetManager_Software>();
            this.AssetManager_Software4 = new List<AssetManager_Software>();
            this.HelpDesk_Tasks = new List<HelpDesk_Tasks>();
            this.HelpDesk_TicketComments = new List<HelpDesk_TicketComments>();
            this.HelpDesk_Tickets = new List<HelpDesk_Tickets>();
            this.HelpDesk_Tickets1 = new List<HelpDesk_Tickets>();
            this.HelpDesk_Tickets2 = new List<HelpDesk_Tickets>();
        }

        public int Id { get; set; }
        public string SID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public Nullable<int> LocationId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public virtual ICollection<AssetManager_AssetAttachments> AssetManager_AssetAttachments { get; set; }
        public virtual ICollection<AssetManager_AssetAttachments> AssetManager_AssetAttachments1 { get; set; }
        public virtual ICollection<AssetManager_AssetStatus> AssetManager_AssetStatus { get; set; }
        public virtual ICollection<AssetManager_AssetStatus> AssetManager_AssetStatus1 { get; set; }
        public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware { get; set; }
        public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware1 { get; set; }
        public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware2 { get; set; }
        public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware3 { get; set; }
        public virtual ICollection<AssetManager_Software> AssetManager_Software { get; set; }
        public virtual ICollection<AssetManager_Software> AssetManager_Software1 { get; set; }
        public virtual ICollection<AssetManager_Software> AssetManager_Software2 { get; set; }
        public virtual ICollection<AssetManager_Software> AssetManager_Software3 { get; set; }
        public virtual ICollection<AssetManager_Software> AssetManager_Software4 { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<HelpDesk_Tasks> HelpDesk_Tasks { get; set; }
        public virtual ICollection<HelpDesk_TicketComments> HelpDesk_TicketComments { get; set; }
        public virtual ICollection<HelpDesk_Tickets> HelpDesk_Tickets { get; set; }
        public virtual ICollection<HelpDesk_Tickets> HelpDesk_Tickets1 { get; set; }
        public virtual ICollection<HelpDesk_Tickets> HelpDesk_Tickets2 { get; set; }
        public virtual NSLocation NSLocation { get; set; }
    }
}
