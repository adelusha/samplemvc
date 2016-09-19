using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tasks;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API
    {
    public class TasksController:ApiController
        {
        private readonly IHelpDeskTaskManager _helpDeskTaskManager;
        private readonly ILogger _logger;
        public TasksController(IHelpDeskTaskManager helpDeskTaskManager, ILogger logger)
        {
            _helpDeskTaskManager = helpDeskTaskManager;
            _logger = logger;
        }

        /// <summary>
        /// Gets the Help Desk tasks
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HelpDesk_Tasks_View_vm> Get()
            {
            _logger.Info("Getting all tasks.");
            return _helpDeskTaskManager.GetAllTasks();
            }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public HelpDesk_Tasks_vm Get(int id)
            {
            _logger.Info("Getting task with id "+ id);
            return _helpDeskTaskManager.GetTaskById(id);
            }

        /// <summary>
        /// Gets the tasks by ticket.
        /// </summary>
        /// <param name="TicketId">The ticket identifier.</param>
        /// <returns></returns>
        public IEnumerable<HelpDesk_Tasks_View_vm> GetTasksByTickets(int TicketId)
            {
            _logger.Info("Getting all tasks for the ticket with id " + TicketId);
            return _helpDeskTaskManager.GetTasksByTicketId(TicketId);
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]HelpDesk_Tasks_vm value)
            {
            _logger.Info("Adding a new task." );
            return _helpDeskTaskManager.CreateTask(value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]HelpDesk_Tasks_vm value)
            {
            _logger.Info("Editing the task with id "+id);
            return _helpDeskTaskManager.EditTask(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the task with the id "+id);
            return _helpDeskTaskManager.DeleteTask(id);
            }
        }
    }