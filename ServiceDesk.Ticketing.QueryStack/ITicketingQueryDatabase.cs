using System.Linq;
using ServiceDesk.Ticketing.Domain.CategoryAggregate;
using ServiceDesk.Ticketing.Domain.TaskAggregate;
using ServiceDesk.Ticketing.Domain.TicketAggregate;
using ServiceDesk.Ticketing.Domain.TicketComment;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.QueryStack
{
    public interface ITicketingQueryDatabase
    {
        IQueryable<TicketState> Tickets { get; }
        IQueryable<CategoryState> Categories { get; }
        IQueryable<TaskState> Tasks { get; }
        IQueryable<TicketCommentState> TicketComments { get; }
        IQueryable<UserState> Users { get; }
    }
}