using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.Domain.Events;
using ServiceDesk.Ticketing.Domain.TicketAggregate;
using System.Diagnostics;

namespace ServiceDesk.Ticketing.CommandStack.Handlers
{
    public class TicketOpenedEventHandler2 : IMessageHandler<TicketOpenedEvent>
    {
        private readonly IBus _bus;
        private readonly ITicketRepository _ticketRepository;

        public TicketOpenedEventHandler2(IBus bus, ITicketRepository ticketRepository /*other dependencies can go here as well*/)
        {
            _ticketRepository = ticketRepository;
            _bus = bus;
        }

        public void Handle(TicketOpenedEvent message)
        {
            var ticketId = message.TicketId;
            Trace.WriteLine("handler2: " + ticketId);
            //do here somethigng interesting when a ticket is opened
        }
    }
}
