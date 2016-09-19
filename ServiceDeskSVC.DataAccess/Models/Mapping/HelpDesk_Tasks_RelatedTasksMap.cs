using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServiceDeskSVC.DataAccess.Models.Mapping
{
    public class HelpDesk_Tasks_RelatedTasksMap : EntityTypeConfiguration<HelpDesk_Tasks_RelatedTasks>
    {
        public HelpDesk_Tasks_RelatedTasksMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("HelpDesk_Tasks_RelatedTasks");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TaskID).HasColumnName("TaskID");
            this.Property(t => t.RelatedTaskID).HasColumnName("RelatedTaskID");
        }
    }
}
