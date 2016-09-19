using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
    {
    public class HelpDeskTaskStatusRepository:IHelpDeskTasksStatusRepository
        {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public HelpDeskTaskStatusRepository(ServiceDeskContext context, ILogger logger)
            {
            _context = context;
            _logger = logger;
            }

        public List<HelpDesk_TaskStatus> GetAllTaskStatuses()
            {
            List<HelpDesk_TaskStatus> allStatuses = _context.HelpDesk_TaskStatus.ToList();
            return allStatuses;
            }

        public bool DeleteTaskStatus(int id)
            {
            bool result = false;
            try
                {
                HelpDesk_TaskStatus oldStatus = _context.HelpDesk_TaskStatus.FirstOrDefault(x => x.Id == id);
                _context.HelpDesk_TaskStatus.Remove(oldStatus);
                _context.SaveChanges();
                result = true;
                _logger.Info("Task Status with id " + id + " was deleted.");
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return result;
            }

        public int CreateTaskStatus(HelpDesk_TaskStatus taskStatus)
            {
            _context.HelpDesk_TaskStatus.Add(taskStatus);
            _context.SaveChanges();

            return taskStatus.Id;
            }

        public int EditTaskStatus(int id, HelpDesk_TaskStatus taskStatus)
            {
            try
                {
                HelpDesk_TaskStatus oldStatus = _context.HelpDesk_TaskStatus.FirstOrDefault(x => x.Id == taskStatus.Id);
                if(oldStatus != null) oldStatus.Status = taskStatus.Status;
                _context.SaveChanges();
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }
            return taskStatus.Id;
            }
        }
    }
