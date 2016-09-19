using System.Linq;
using ServiceDesk.Ticketing.DataAccess;
using ServiceDesk.Ticketing.Domain.CategoryAggregate;
using ServiceDesk.Ticketing.Domain.TaskAggregate;
using ServiceDesk.Ticketing.Domain.TicketAggregate;
using ServiceDesk.Ticketing.Domain.TicketComment;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.QueryStack
{
    public class TicketingQueryDatabase : ITicketingQueryDatabase
    {
        private readonly TicketingDbContext _context;

        public TicketingQueryDatabase(TicketingDbContext context)
        {
            _context = context;
        }

        public IQueryable<TicketState> Tickets
        {
            get { return _context.Tickets; }
        }

        public IQueryable<CategoryState> Categories
        {
            get { return _context.Categories; }
        }

        public IQueryable<TaskState> Tasks
        {
            get { return _context.Tasks; }
        }

        public IQueryable<UserState> Users
        {
            get { return _context.Users; }
        }

        public IQueryable<TicketCommentState> TicketComments
        {
            get { return _context.TicketComments; }
        }
    }
}