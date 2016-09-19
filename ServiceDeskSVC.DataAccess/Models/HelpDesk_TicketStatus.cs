using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class HelpDesk_TicketStatus
    {
        public HelpDesk_TicketStatus()
        {
            this.HelpDesk_Tickets = new List<HelpDesk_Tickets>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public virtual ICollection<HelpDesk_Tickets> HelpDesk_Tickets { get; set; }
    }
}
