using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class HelpDesk_TicketAttachmentsMap : EntityTypeConfiguration<HelpDesk_TicketAttachments>
    {
        public HelpDesk_TicketAttachmentsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FileName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Data)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("HelpDesk_TicketAttachments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TicketId).HasColumnName("TicketId");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.FileSize).HasColumnName("FileSize");

            // Relationships
            this.HasRequired(t => t.HelpDesk_Tickets)
                .WithMany(t => t.HelpDesk_TicketAttachments)
                .HasForeignKey(d => d.TicketId);

        }
    }
}
