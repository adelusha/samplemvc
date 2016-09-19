using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class ServiceDesk_UsersMap : EntityTypeConfiguration<ServiceDesk_Users>
    {
        public ServiceDesk_UsersMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.EMail)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ServiceDesk_Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SID).HasColumnName("SID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.EMail).HasColumnName("EMail");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.DepartmentId).HasColumnName("DepartmentId");

            // Relationships
            this.HasOptional(t => t.Department)
                .WithMany(t => t.ServiceDesk_Users)
                .HasForeignKey(d => d.DepartmentId);
            this.HasOptional(t => t.NSLocation)
                .WithMany(t => t.ServiceDesk_Users)
                .HasForeignKey(d => d.LocationId);

        }
    }
}
