using System;
using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.Domain.CategoryAggregate;
using ServiceDesk.Ticketing.Domain.TaskAggregate;
using ServiceDesk.Ticketing.Domain.TicketComment;
using ServiceDesk.Ticketing.Domain.UserAggregate;
using TaskStatus = ServiceDesk.Ticketing.Domain.TaskAggregate.TaskStatus;

namespace ServiceDesk.Ticketing.Domain.TicketAggregate
    {
    public class Ticket : AggregateRoot
        {
        internal TicketState State { get; set; }

        public Guid Id
            {
            get { return State.Id; }
            }

        public Ticket(string title, string description, TicketStatus status, TicketPriority priority, TicketType type, DateTime? dueDate, string resolutionComments, User requestor, User assignedTo, Category category)
            {
            State = new TicketState
            {
                Id = SequencialGuidGenerator.NewSequentialGuid(),
                TicketNumber = new Random().Next(),
                Title = title,
                Description = description,
                Status = status,
                Priority = priority,
                Type = type,
                DueDate = dueDate,
                ResolutionComments = resolutionComments,
                Requestor = requestor.CreateRequestorSnapShot(),
                RequestedDate = DateTime.UtcNow,
                AssignedTo = assignedTo.State,
                Category = category.State
            };
            }

        internal Ticket(TicketState state)
            {
            State = state;
            }

        public void UpdateTicket(string title, string description, int status, int priority, int type,
            DateTime? dueDate, string resolutionComments, User assignedTo, Category category)
            {
            State.Title = title;
            State.Description = description;
            State.Status = (TicketStatus)status;
            State.Priority = (TicketPriority)priority;
            State.Type = (TicketType)type;
            State.DueDate = dueDate;
            State.ResolutionComments = resolutionComments;
            State.AssignedTo = assignedTo.State;
            State.Category = category.State;
           
            }

        public void AddTask(string title, string description, User assignedTo, TaskStatus status)
            {
            var task = new TaskState
            {
                Id = SequencialGuidGenerator.NewSequentialGuid(),
                TaskNumber = new Random().Next(),
                Title = title,
                Description = description,
                AssignedTo = assignedTo.State,
                CreatedDateTime = DateTime.UtcNow,
                Status = status
            };

            State.Tasks.Add(task);
            }

        public void AddComment(string comment, User user)
        {
            var ticketComment = new TicketCommentState
            {
                Id = SequencialGuidGenerator.NewSequentialGuid(),
                Comment = comment,
                User = user.State,
                CreatedOn = DateTime.UtcNow
            };

            State.Comments.Add(ticketComment);
        }

        public void UpdateTask(string title, string description, User assignedTo, TaskStatus status, int id)
        {
            Task task = State.Tasks.Find(t => t.TaskNumber == id).ToTask();
            task.UpdateTask(title, description, status,assignedTo);
        }
        }
    }