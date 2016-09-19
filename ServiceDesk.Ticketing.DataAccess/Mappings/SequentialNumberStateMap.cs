using System.Data.Entity.ModelConfiguration;
using ServiceDesk.Ticketing.Domain.TicketAggregate;

namespace ServiceDesk.Ticketing.DataAccess.Mappings
{
    public class SequentialNumberStateMap : EntityTypeConfiguration<SequentialNumberState>
    {
        public SequentialNumberStateMap()
        {
            ToTable("SequentialNumber");
        }
    }
}
