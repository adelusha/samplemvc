namespace ServiceDesk.Ticketing.Domain.TicketAggregate
{
    public enum TicketStatus
    {
        Open = 0,
        Deferred = 1,
        Resolved = 2,
        Closed = 3
    }
}