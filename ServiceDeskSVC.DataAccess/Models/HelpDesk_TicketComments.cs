using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class HelpDesk_TicketComments
    {
        public int Id { get; set; }
        public int TicketID { get; set; }
        public System.DateTime CommentDateTime { get; set; }
        public int Author { get; set; }
        public int CommentTypeID { get; set; }
        public string Comment { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users { get; set; }
        public virtual HelpDesk_Tickets HelpDesk_Tickets { get; set; }
    }
}
