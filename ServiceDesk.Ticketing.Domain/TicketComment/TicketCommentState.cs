using System;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.Domain.TicketComment
{
    public class TicketCommentState
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual UserState User { get; set; }
    }
}
