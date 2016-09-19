using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class HelpDesk_TicketDocuments
    {
        public int Id { get; set; }
        public string DocumentPath { get; set; }
        public int TicketID { get; set; }
        public virtual HelpDesk_Tickets HelpDesk_Tickets { get; set; }
    }
}
