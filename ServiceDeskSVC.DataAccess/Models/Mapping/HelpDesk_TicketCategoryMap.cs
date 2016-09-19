using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class HelpDesk_TicketCategoryMap : EntityTypeConfiguration<HelpDesk_TicketCategory>
    {
        public HelpDesk_TicketCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("HelpDesk_TicketCategory");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Category).HasColumnName("Category");
        }
    }
}
