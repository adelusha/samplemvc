using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ServiceDesk.Ticketing.DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : AggregateRoot
    {
        private readonly DbContext _context;
        private readonly IBus _bus;

        protected RepositoryBase(DbContext context, IBus bus)
        {
            _bus = bus;
            _context = context;
        }

        public void Add(T aggregate)
        {
            AddNew(aggregate);

            PublishEvents(aggregate);
            _context.SaveChanges();
        }

        public void Update(T aggregate)
        {
            PublishEvents(aggregate);
            // possible performce improvements here
            _context.SaveChanges();
        }

        private void PublishEvents(T aggregate)
        {
            if (aggregate.HasPendingChanges)
            {
                IEnumerable<DomainEvent> events = aggregate.GetUncommittedEvents();
                events.ToList().ForEach(e => _bus.RaiseEvent(e));
                aggregate.ClearUncommittedEvents();
            }
        }

        protected abstract void AddNew(T aggregate);
    }
}