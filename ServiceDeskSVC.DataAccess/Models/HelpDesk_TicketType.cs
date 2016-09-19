using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class HelpDesk_TicketType
    {
        public HelpDesk_TicketType()
        {
            this.HelpDesk_Tickets = new List<HelpDesk_Tickets>();
        }

        public int Id { get; set; }
        public string TicketType { get; set; }
        public virtual ICollection<HelpDesk_Tickets> HelpDesk_Tickets { get; set; }
    }
}
