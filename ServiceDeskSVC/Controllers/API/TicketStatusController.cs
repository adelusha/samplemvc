using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API
    {
    /// <summary>
    /// 
    /// </summary>
    public class TicketStatusController:ApiController
        {
        private readonly IHelpDeskTicketStatusManager _helpDeskTicketStatusManager;
        private readonly ILogger _logger;

        public TicketStatusController(IHelpDeskTicketStatusManager helpDeskTicketStatusManager, ILogger logger)
            {
            _helpDeskTicketStatusManager = helpDeskTicketStatusManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HelpDesk_TicketStatus_vm> Get()
            {
            _logger.Info("Getting all ticket statuses. ");
            return _helpDeskTicketStatusManager.GetAllStatuses();
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]HelpDesk_TicketStatus_vm value)
        {
            _logger.Info("Adding a new ticket status. ");
            return _helpDeskTicketStatusManager.CreateStatus(value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]HelpDesk_TicketStatus_vm value)
        {
            _logger.Info("Editing the ticket status with id" + id);
            return _helpDeskTicketStatusManager.EditStatusById(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the ticket status with id" + id);
            return _helpDeskTicketStatusManager.DeleteStatusById(id);
            }
        }
    }