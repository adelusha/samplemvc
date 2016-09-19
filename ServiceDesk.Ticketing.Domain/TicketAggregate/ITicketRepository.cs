
using System;

namespace ServiceDesk.Ticketing.Domain.TicketAggregate
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Ticket GetById(/*TicketId ticketId*/Guid id);
        Ticket GetByTicketNumber(int id);
    }
}
