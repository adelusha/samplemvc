using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class HelpDesk_TicketTypeMap : EntityTypeConfiguration<HelpDesk_TicketType>
    {
        public HelpDesk_TicketTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TicketType)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("HelpDesk_TicketType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TicketType).HasColumnName("TicketType");
        }
    }
}
