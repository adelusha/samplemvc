using System.Linq;
using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.Domain.CategoryAggregate;

namespace ServiceDesk.Ticketing.DataAccess.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly TicketingDbContext _context;

        public CategoryRepository(TicketingDbContext context, IBus bus)
            : base(context, bus)
        {
            _context = context;
        }

        public Category GetByName(string  name)
        {
            return _context.Categories.First(c=>c.Name == name).ToCategory();
        }

        protected override void AddNew(Category aggregate)
        {
            _context.Categories.Add(aggregate.State);
        }
    }
}
