using System;
using ServiceDesk.Infrastructure;

namespace ServiceDesk.Ticketing.Domain.Events
{
    public class TicketOpenedEvent : DomainEvent
    {
        public Guid TicketId { get; private set; }
        //add here other pieces of interesting data

        public TicketOpenedEvent(Guid ticketId)
        {
            TicketId = ticketId;
        }
    }
}
