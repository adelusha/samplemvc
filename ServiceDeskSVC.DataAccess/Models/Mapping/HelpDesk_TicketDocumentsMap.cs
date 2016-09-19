using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class HelpDesk_TicketDocumentsMap : EntityTypeConfiguration<HelpDesk_TicketDocuments>
    {
        public HelpDesk_TicketDocumentsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.DocumentPath)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("HelpDesk_TicketDocuments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DocumentPath).HasColumnName("DocumentPath");
            this.Property(t => t.TicketID).HasColumnName("TicketID");

            // Relationships
            this.HasRequired(t => t.HelpDesk_Tickets)
                .WithMany(t => t.HelpDesk_TicketDocuments)
                .HasForeignKey(d => d.TicketID);

        }
    }
}
