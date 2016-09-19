using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class HelpDesk_TaskStatusMap : EntityTypeConfiguration<HelpDesk_TaskStatus>
    {
        public HelpDesk_TaskStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("HelpDesk_TaskStatus");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
