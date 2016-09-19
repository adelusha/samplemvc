using System;

namespace ServiceDeskSVC.Models.Ticketing
{
    public class TicketCommentViewModel
    {
        public string Comment { get; set; }
        public string User { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}