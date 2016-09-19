using System.ComponentModel.DataAnnotations;

namespace ServiceDesk.Ticketing.Domain.TicketAggregate
{
    public class SequentialNumberState
    {
        [Key]
        public int Number { get; set; }
    }
}
