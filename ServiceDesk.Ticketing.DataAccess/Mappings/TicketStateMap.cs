using System.Data.Entity.ModelConfiguration;
using ServiceDesk.Ticketing.Domain.TicketAggregate;

namespace ServiceDesk.Ticketing.DataAccess.Mappings
{
    public class TicketStateMap : EntityTypeConfiguration<TicketState>
    {
        public TicketStateMap()
        {
            ToTable("Tickets");
        }
    }
}
