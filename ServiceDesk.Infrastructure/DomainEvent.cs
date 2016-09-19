using System;

namespace ServiceDesk.Infrastructure
{
    public class DomainEvent : Message
    {
        public DateTime Timestamp { get; private set; }

        public DomainEvent()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
