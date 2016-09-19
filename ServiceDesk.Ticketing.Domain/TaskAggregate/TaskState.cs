using System;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.Domain.TaskAggregate
{
    public class TaskState
    {
        public Guid Id { get; set; }
        public int TaskNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public TaskStatus Status { get; set; }
        public virtual UserState AssignedTo { get; set; }

        public Task ToTask()
        {
            return new Task(this);
        }

        public static Task ToTask(TaskState state)
        {
            return new Task(state);
        }
    }
}