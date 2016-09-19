
namespace ServiceDesk.Infrastructure
{
    public interface IBus
    {
        void Send<T>(T command) where T : Command;
        void RaiseEvent<T>(T @event) where T : DomainEvent;
    }
}
