using System;
using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDesk.Ticketing.Domain.TaskAggregate
{
    public class Task
    {
        internal TaskState State { get; set; }

        public Guid Id
        {
            get { return State.Id; }
        }

        public Task(string title, string description, DateTime createdDateTime,
            TaskStatus status, User assignedTo)
        {
            State = new TaskState
            {
                Id = SequencialGuidGenerator.NewSequentialGuid(),
                TaskNumber = new Random().Next(),
                Title = title,
                Description = description,
                CreatedDateTime = createdDateTime,
                Status = status,
                AssignedTo = assignedTo.State
            };
        }

        public void UpdateTask(string title, string description, TaskStatus status, User assignedTo)
        {
            State.Title = title;
            State.Description = description;
            State.Status = status;
            State.AssignedTo = assignedTo.State;
        }

        internal Task(TaskState state)
        {
            State = state;
        }
    }
}
