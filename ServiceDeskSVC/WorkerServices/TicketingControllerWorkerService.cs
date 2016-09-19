using System;
using System.Linq;
using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.CommandStack.Commands;
using ServiceDesk.Ticketing.Domain.TaskAggregate;
using ServiceDesk.Ticketing.Domain.TicketAggregate;
using ServiceDesk.Ticketing.QueryStack;
using ServiceDeskSVC.Controllers.API.Ticketing;
using ServiceDeskSVC.Models.Ticketing;

namespace ServiceDeskSVC.WorkerServices
{
    public class TicketingControllerWorkerService
    {
        private readonly IBus _bus;
        private readonly ITicketingQueryDatabase _database;

        public TicketingControllerWorkerService(IBus bus, ITicketingQueryDatabase database)
        {
            _database = database;
            _bus = bus;
        }

        public void CreateNewTicket(TicketInputModel model)
        {
            var cmd = new CreateTicketCommand(model.Title, model.Description, model.Status, model.Priority, model.Type,
           model.DueDate, model.ResolutionComments, model.RequestorLoginName, model.AssignedToLoginName, model.Category);
            _bus.Send(cmd);
        }

        public TicketViewModel GetTicket(int id)
        {
            var ticket = _database.Tickets.First(t => t.TicketNumber == id);
            TicketViewModel model = new TicketViewModel
            {
                TicketNumber = ticket.TicketNumber,
                Title = ticket.Title,
                Description = ticket.Description,
                AssignedTo = ticket.AssignedTo.DisplayName,
                AssignedToLoginName = ticket.AssignedTo.LoginName,
                Category = ticket.Category.Name,
                DueDate = ticket.DueDate,
                PriorityNo = (int)ticket.Priority,
                Priority = Enum.GetName(typeof(TicketPriority), ticket.Priority),
                RequestedDate = ticket.RequestedDate,
                Requestor_Departament = ticket.Requestor.Departament,
                Requestor_DisplayName = ticket.Requestor.DisplayName,
                Requestor_Location = ticket.Requestor.Location,
                StatusNo = (int)ticket.Status,
                Status = Enum.GetName(typeof(TicketStatus), ticket.Status),
                TypeNo = (int)ticket.Type,
                Type = Enum.GetName(typeof(TicketType), ticket.Type),
                ResolutionComments = ticket.ResolutionComments
            };

            return model;
        }

        public void UpdateTicket(int id, TicketUpdateModel model)
        {
            var cmd = new UpdateTicketCommand(id, model.Title, model.Description, model.Status, model.Priority, model.Type,
           model.DueDate, model.ResolutionComments, model.AssignedToLoginName, model.Category);
            _bus.Send(cmd);
        }

        public AllTicketsModel GetAllTickets()
        {
            var tickets = _database.Tickets.Select(t => new TicketViewModel
                {
                    TicketNumber = t.TicketNumber,
                    Title = t.Title,
                    Requestor_DisplayName = t.Requestor.DisplayName,
                    Requestor_Departament = t.Requestor.Departament,
                    Requestor_Location = t.Requestor.Location,
                    RequestedDate = t.RequestedDate,
                    DueDate = t.DueDate,
                    Category = t.Category.Name,
                    Type = t.Type.ToString(),
                    Priority = t.Priority.ToString(),
                    Status = t.Status.ToString(),
                    AssignedTo = t.AssignedTo.DisplayName
                });

            return new AllTicketsModel { AllTickets = tickets.ToList() };
        }

        public AllCategoriesModel GetAllCategories()
        {
            var categories = _database.Categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });

            return new AllCategoriesModel { AllCategories = categories.ToList() };
        }

        public void CreateNewTask(int id, TaskInputModel model)
        {
            var command = new CreateTaskCommand(model.Title, model.Description, model.Status, model.AssignedTo, id);
            _bus.Send(command);
        }

        public void UpdateTask(int ticketId, int id, UpdateTaskViewModel model)
        {
            var command = new UpdateTaskCommand(model.Title, model.Description, model.Status, model.AssignedTo, ticketId, id);
            _bus.Send(command);
        }

        public AllTasksModel GetTasksForTicket(int id)
        {
            var tasks = _database.Tickets
                .First(x => x.TicketNumber == id)
                .Tasks
                .Select(task => new TaskViewModel
            {
                TaskNumber = task.TaskNumber,
                Title = task.Title,
                AssignedTo = task.AssignedTo.DisplayName,
                CreatedDate = task.CreatedDateTime,
                Status = Enum.GetName(typeof(TaskStatus), (int)task.Status)
            });

            return new AllTasksModel { Tasks = tasks.ToList() };
        }

        public TaskViewModel GetTask(int id)
        {
            var task = _database.Tasks.First(x => x.TaskNumber == id);
            TaskViewModel model = new TaskViewModel
            {
                Title = task.Title,
                Description = task.Description,
                TaskNumber = task.TaskNumber,
                AssignedTo = task.AssignedTo.DisplayName,
                StatusId = (int)task.Status,
                Status = Enum.GetName(typeof(TaskStatus), task.Status),
                CreatedDate = task.CreatedDateTime,
            };
            return model;
        }

        public AllTicketCommentsModel GetCommentsForTicket(int id)
        {
            var comments = _database.Tickets.First(c => c.TicketNumber == id)
                .Comments.Select(comment => new TicketCommentViewModel
                {
                    Comment = comment.Comment,
                    User = comment.User.DisplayName,
                    CreatedOn = comment.CreatedOn
                });

            return new AllTicketCommentsModel { AllComments = comments.ToList() };
        }

        public void CreateTicketComment(int id, TicketCommentInputModel model)
        {
            var command = new CreateTicketCommentCommand(id, model.Comment, model.UserLoginName);
            _bus.Send(command);
        }

        public void RefreshUsers()
        {
            var command = new RefreshUsersCommand();
            _bus.Send(command);
        }
    }
}