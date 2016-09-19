using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class HelpDesk_TicketStatusMap : EntityTypeConfiguration<HelpDesk_TicketStatus>
    {
        public HelpDesk_TicketStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("HelpDesk_TicketStatus");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
