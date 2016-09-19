using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class HelpDesk_TicketAttachments
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string FileName { get; set; }
        public System.DateTime Date { get; set; }
        public byte[] Data { get; set; }
        public int FileSize { get; set; }
        public virtual HelpDesk_Tickets HelpDesk_Tickets { get; set; }
    }
}
