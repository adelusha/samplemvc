using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class HelpDesk_TicketCategory
    {
        public HelpDesk_TicketCategory()
        {
            this.HelpDesk_Tickets = new List<HelpDesk_Tickets>();
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public virtual ICollection<HelpDesk_Tickets> HelpDesk_Tickets { get; set; }
    }
}
