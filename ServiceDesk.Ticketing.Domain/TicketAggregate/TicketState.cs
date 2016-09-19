using System;
using System.Collections.Generic;
using ServiceDesk.Ticketing.Domain.CategoryAggregate;
using ServiceDesk.Ticketing.Domain.TaskAggregate;
using ServiceDesk.Ticketing.Domain.TicketComment;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.Domain.TicketAggregate
{
    public class TicketState
    {
        public Guid Id { get; set; }
        public int TicketNumber { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
        public TicketType Type { get; set; }
        public DateTime? DueDate { get; set; }
        public string ResolutionComments { get; set; }
        public Requestor Requestor { get; set; }
        public DateTime RequestedDate { get; set; }
        public virtual UserState AssignedTo { get; set; }
        public virtual CategoryState Category { get; set; }
        public virtual List<TaskState> Tasks { get; set; }
        public virtual List<TicketCommentState> Comments { get; set; }

        public Ticket ToTicket()
        {
            return new Ticket(this);
        }

        public static Ticket ToTicket(TicketState state)
        {
            return new Ticket(state);
        }
    }
}