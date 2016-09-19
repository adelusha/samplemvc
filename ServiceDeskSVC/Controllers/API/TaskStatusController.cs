using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tasks;
using ServiceDeskSVC.Managers;


namespace ServiceDeskSVC.Controllers.API
{
    public class TaskStatusController : ApiController
    {
        private readonly IHelpDeskTaskStatusManager _helpDeskTaskStatusManager;
        private readonly ILogger _logger;
        public TaskStatusController(IHelpDeskTaskStatusManager helpDeskTaskStatusManager, ILogger logger)
            {
            _helpDeskTaskStatusManager = helpDeskTaskStatusManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HelpDesk_TaskStatus_vm> Get()
            {
            _logger.Info("Getting all task statuses.");
            return _helpDeskTaskStatusManager.GetAllTaskStatuses();
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]HelpDesk_TaskStatus_vm value)
            {
            _logger.Info("Creating a new task status.");
            return _helpDeskTaskStatusManager.CreateTaskStatus(value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]HelpDesk_TaskStatus_vm value)
            {
            _logger.Info("Editing the task with id "+ id);
            return _helpDeskTaskStatusManager.EditTaskStatusById(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the task with id "+id);
            return _helpDeskTaskStatusManager.DeleteTaskStatusById(id);
            }
        }
}
