using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class HelpDesk_TicketCommentsMap : EntityTypeConfiguration<HelpDesk_TicketComments>
    {
        public HelpDesk_TicketCommentsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Comment)
                .IsRequired()
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("HelpDesk_TicketComments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TicketID).HasColumnName("TicketID");
            this.Property(t => t.CommentDateTime).HasColumnName("CommentDateTime");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.CommentTypeID).HasColumnName("CommentTypeID");
            this.Property(t => t.Comment).HasColumnName("Comment");

            // Relationships
            this.HasRequired(t => t.ServiceDesk_Users)
                .WithMany(t => t.HelpDesk_TicketComments)
                .HasForeignKey(d => d.Author);
            this.HasRequired(t => t.HelpDesk_Tickets)
                .WithMany(t => t.HelpDesk_TicketComments)
                .HasForeignKey(d => d.TicketID);

        }
    }
}
