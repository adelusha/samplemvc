
using ServiceDesk.Infrastructure;

namespace ServiceDesk.Ticketing.Domain
{
    public interface IRepository<in T> where T : AggregateRoot
    {
        void Add(T aggregate);
        void Update(T aggregate);
    }
}
