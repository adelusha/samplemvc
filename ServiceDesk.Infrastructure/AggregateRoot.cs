using System.Collections.Generic;
using System.Linq;

namespace ServiceDesk.Infrastructure
{
    public abstract class AggregateRoot
    {
        private readonly IList<DomainEvent> _uncommittedEvents = new List<DomainEvent>();

        public bool HasPendingChanges
        {
            get { return _uncommittedEvents.Any(); }
        }

        public IEnumerable<DomainEvent> GetUncommittedEvents()
        {
            return _uncommittedEvents;
        }

        public void ClearUncommittedEvents()
        {
            _uncommittedEvents.Clear();
        }

        protected void RaiseEvent(DomainEvent @event)
        {
            _uncommittedEvents.Add(@event);
        }
    }
}
