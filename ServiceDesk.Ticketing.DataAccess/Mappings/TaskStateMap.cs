using System.Data.Entity.ModelConfiguration;
using ServiceDesk.Ticketing.Domain.TaskAggregate;

namespace ServiceDesk.Ticketing.DataAccess.Mappings
{
    public class TaskStateMap : EntityTypeConfiguration<TaskState>
    {
        public TaskStateMap()
        {
            ToTable("Tasks");
        }
    }
}