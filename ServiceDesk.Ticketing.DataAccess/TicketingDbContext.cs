using ServiceDesk.Ticketing.DataAccess.Mappings;
using ServiceDesk.Ticketing.Domain.CategoryAggregate;
using ServiceDesk.Ticketing.Domain.TaskAggregate;
using ServiceDesk.Ticketing.Domain.TicketAggregate;
using System.Data.Entity;
using ServiceDesk.Ticketing.Domain.TicketComment;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.DataAccess
{
    public class TicketingDbContext : DbContext
    {
        public TicketingDbContext()
            : base("ServiceDeskDb")
        {

        }

        public DbSet<TicketState> Tickets { get; set; }
        public DbSet<UserState> Users { get; set; }
        public DbSet<CategoryState> Categories { get; set; }
        public DbSet<TaskState> Tasks { get; set; }
        public DbSet<TicketCommentState> TicketComments { get; set; }
        public DbSet<SequentialNumberState> SequentialNumbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Ticketing");

            modelBuilder.Configurations.Add(new TicketStateMap());
            modelBuilder.Configurations.Add(new UserStateMap());
            modelBuilder.Configurations.Add(new CategoryStateMap());
            modelBuilder.Configurations.Add(new TaskStateMap());
            modelBuilder.Configurations.Add(new TicketCommentStateMap());
            modelBuilder.Configurations.Add(new SequentialNumberStateMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
