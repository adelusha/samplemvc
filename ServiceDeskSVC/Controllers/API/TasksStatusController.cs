using System.Collections.Generic;
using System.Web.Http;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tasks;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API
    {

    public class TaskStatusController:ApiController
        {
        private readonly IHelpDeskTaskStatusManager _helpDeskTaskStatusManager;

        public TaskStatusController(IHelpDeskTaskStatusManager helpDeskTaskStatusManager)
            {
            _helpDeskTaskStatusManager = helpDeskTaskStatusManager;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HelpDesk_TaskStatus_vm> Get()
            {
            return _helpDeskTaskStatusManager.GetAllTaskStatuses();
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]HelpDesk_TaskStatus_vm value)
            {
            var result = _helpDeskTaskStatusManager.CreateTaskStatus(value);
            return Ok(result);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, [FromBody]HelpDesk_TaskStatus_vm value)
            {
            var result = _helpDeskTaskStatusManager.EditTaskStatusById(id, value);
            if(result ==0 )
                {
                return NotFound(); // Returns a NotFoundResult
                }
            return Ok(result);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
            {
            var result= _helpDeskTaskStatusManager.DeleteTaskStatusById(id);
            return Ok(result);
            }
        }
    }
