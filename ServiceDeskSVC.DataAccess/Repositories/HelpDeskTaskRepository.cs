using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
{
    public class HelpDeskTaskRepository : IHelpDeskTasksRepository
    {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public HelpDeskTaskRepository(ServiceDeskContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<HelpDesk_Tasks> GetAllTasks()
        {
            List<HelpDesk_Tasks> allTasks = _context.HelpDesk_Tasks.ToList();
            return allTasks;
        }

        public HelpDesk_Tasks GetTaskById(int id)
        {
            HelpDesk_Tasks task = _context.HelpDesk_Tasks.FirstOrDefault(x => x.Id == id);
            return task;
        }

        public List<HelpDesk_Tasks> GetTasksByUser(string userName)
            {
            //List<HelpDesk_Tasks> allTasksByUser =
            //    _context.HelpDesk_Tasks.Where(
            //        x =>
            //            x.AssignedTo.Contains(userName)).ToList();
            //return allTasksByUser;
            return null;
            }

        public List<HelpDesk_Tasks> GetTasksByTicketId(int ticketId)
        {
            HelpDesk_Tickets ticket = _context.HelpDesk_Tickets.First(x => x.TicketNumber == ticketId);
            List<HelpDesk_Tasks> allTasksByTicket = _context.HelpDesk_Tasks.Where(x => x.TicketID == ticket.Id).ToList();
            return allTasksByTicket;
        }

        public int CreateTask(HelpDesk_Tasks task)
        {
            HelpDesk_Tickets ticket = _context.HelpDesk_Tickets.First(x => x.TicketNumber == task.TicketID);
            task.TicketID = ticket.Id;
            _context.HelpDesk_Tasks.Add(task);
            _context.SaveChanges();
            return task.Id;
        }

        public int EditTask(int id, HelpDesk_Tasks task)
        {
            HelpDesk_Tasks oldTask = _context.HelpDesk_Tasks.FirstOrDefault(x => x.Id == id);
            try
            {
                if (oldTask != null)
                {
                    oldTask.TicketID = task.TicketID;
                    oldTask.Title = task.Title;
                    oldTask.AssignedTo = task.AssignedTo;
                    oldTask.Description = task.Description;
                    oldTask.StatusID = task.StatusID;
                    oldTask.StatusChangedDateTime = task.StatusChangedDateTime;
                    oldTask.RelatedTaskIds = task.RelatedTaskIds;
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return task.Id;
        }

        public bool DeleteTask(int id)
        {
            bool result = false;
            try
            {
                HelpDesk_Tasks task = _context.HelpDesk_Tasks.FirstOrDefault(x => x.Id == id);
                _context.HelpDesk_Tasks.Remove(task);
                _context.SaveChanges();
                result = true;
                _logger.Info("Task with id " + id + " was deleted.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return result;
        }
    }
}
