using ServiceDesk.Ticketing.Domain.TicketAggregate;
using System.Linq;

namespace ServiceDesk.Ticketing.QueryStack.Extensions
{
    public static class TicketExtensions
    {
        public static IQueryable<TicketState> WithTitleInTheFirstHalfOfTheAlphabet(this IQueryable<TicketState> tickets)
        {
            return tickets.Where(t => t.Title.StartsWith("a"));
        }

        //more queries that match the domain language can be added here
    }
}
