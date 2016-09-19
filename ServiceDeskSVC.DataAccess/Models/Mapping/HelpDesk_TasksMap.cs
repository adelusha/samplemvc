using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class HelpDesk_TasksMap : EntityTypeConfiguration<HelpDesk_Tasks>
    {
        public HelpDesk_TasksMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.RelatedTaskIds)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("HelpDesk_Tasks");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TicketID).HasColumnName("TicketID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.StatusChangedDateTime).HasColumnName("StatusChangedDateTime");
            this.Property(t => t.AssignedTo).HasColumnName("AssignedTo");
            this.Property(t => t.RelatedTaskIds).HasColumnName("RelatedTaskIds");

            // Relationships
            this.HasRequired(t => t.HelpDesk_TaskStatus)
                .WithMany(t => t.HelpDesk_Tasks)
                .HasForeignKey(d => d.StatusID);
            this.HasRequired(t => t.HelpDesk_Tickets)
                .WithMany(t => t.HelpDesk_Tasks)
                .HasForeignKey(d => d.TicketID);
            this.HasRequired(t => t.ServiceDesk_Users)
                .WithMany(t => t.HelpDesk_Tasks)
                .HasForeignKey(d => d.AssignedTo);

        }
    }
}
