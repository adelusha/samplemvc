using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class HelpDesk_TicketsMap : EntityTypeConfiguration<HelpDesk_Tickets>
    {
        public HelpDesk_TicketsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.VendorTicket)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("HelpDesk_Tickets");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TicketNumber).HasColumnName("TicketNumber");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Requestor).HasColumnName("Requestor");
            this.Property(t => t.DepartmentID).HasColumnName("DepartmentID");
            this.Property(t => t.LocationID).HasColumnName("LocationID");
            this.Property(t => t.RequestDateTime).HasColumnName("RequestDateTime");
            this.Property(t => t.RequestedDueDate).HasColumnName("RequestedDueDate");
            this.Property(t => t.TicketCategoryID).HasColumnName("TicketCategoryID");
            this.Property(t => t.PriorityCode).HasColumnName("PriorityCode");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.AssignedTo).HasColumnName("AssignedTo");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.VendorTicket).HasColumnName("VendorTicket");
            this.Property(t => t.TicketTypeID).HasColumnName("TicketTypeID");
            this.Property(t => t.NeedsApproval).HasColumnName("NeedsApproval");
            this.Property(t => t.ApprovedBy).HasColumnName("ApprovedBy");
            this.Property(t => t.ApprovedOn).HasColumnName("ApprovedOn");

            // Relationships
            this.HasOptional(t => t.AssetManager_Companies)
                .WithMany(t => t.HelpDesk_Tickets)
                .HasForeignKey(d => d.VendorID);
            this.HasRequired(t => t.Department)
                .WithMany(t => t.HelpDesk_Tickets)
                .HasForeignKey(d => d.DepartmentID);
            this.HasRequired(t => t.HelpDesk_TicketCategory)
                .WithMany(t => t.HelpDesk_Tickets)
                .HasForeignKey(d => d.TicketCategoryID);
            this.HasOptional(t => t.ServiceDesk_Users)
                .WithMany(t => t.HelpDesk_Tickets)
                .HasForeignKey(d => d.ApprovedBy);
            this.HasRequired(t => t.ServiceDesk_Users1)
                .WithMany(t => t.HelpDesk_Tickets1)
                .HasForeignKey(d => d.AssignedTo);
            this.HasRequired(t => t.NSLocation)
                .WithMany(t => t.HelpDesk_Tickets)
                .HasForeignKey(d => d.LocationID);
            this.HasRequired(t => t.ServiceDesk_Users2)
                .WithMany(t => t.HelpDesk_Tickets2)
                .HasForeignKey(d => d.Requestor);
            this.HasRequired(t => t.HelpDesk_TicketStatus)
                .WithMany(t => t.HelpDesk_Tickets)
                .HasForeignKey(d => d.StatusID);
            this.HasRequired(t => t.HelpDesk_TicketType)
                .WithMany(t => t.HelpDesk_Tickets)
                .HasForeignKey(d => d.TicketTypeID);

        }
    }
}
