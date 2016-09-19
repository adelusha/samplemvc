using System.Data.Entity.ModelConfiguration;
using ServiceDesk.Ticketing.Domain.TicketComment;

namespace ServiceDesk.Ticketing.DataAccess.Mappings
{
    internal class TicketCommentStateMap : EntityTypeConfiguration<TicketCommentState>
    {
        public TicketCommentStateMap()
        {
            ToTable("TicketComments");
        }
    }
}
