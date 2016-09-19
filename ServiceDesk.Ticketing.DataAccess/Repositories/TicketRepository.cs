using System.Linq;
using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.Domain.TicketAggregate;
using System;

namespace ServiceDesk.Ticketing.DataAccess.Repositories
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        private readonly TicketingDbContext _context;

        public TicketRepository(TicketingDbContext context, IBus bus)
            : base(context, bus)
        {
            _context = context;
        }

        public Ticket GetById(Guid id)
        {
            return _context.Tickets.Find(id).ToTicket();
        }

        public Ticket GetByTicketNumber(int id)
        {
            return _context.Tickets.First(x => x.TicketNumber == id).ToTicket();
        }

        protected override void AddNew(Ticket aggregate)
        {
            _context.Tickets.Add(aggregate.State);
        }
    }
}
