using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API
    {
    public class TicketTypeController:ApiController
        {
        private readonly IHelpDeskTicketTypeManager _helpDeskTicketTypeManager;
        private readonly ILogger _logger;
        public TicketTypeController(IHelpDeskTicketTypeManager helpDeskTicketTypeManager, ILogger logger)
            {
            _helpDeskTicketTypeManager = helpDeskTicketTypeManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HelpDesk_TicketType_vm> Get()
            {
            _logger.Info("Getting all ticket types.");
            return _helpDeskTicketTypeManager.GetAllTicketTypes();
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]HelpDesk_TicketType_vm value)
            {
            _logger.Info("Adding a new ticket type.");
            return _helpDeskTicketTypeManager.CreateTicketType(value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]HelpDesk_TicketType_vm value)
            {
            _logger.Info("Editing the ticket type wiht id" + id);
            return _helpDeskTicketTypeManager.EditTicketTypeById(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the ticket type with id " + id);
            return _helpDeskTicketTypeManager.DeleteTicketTypeById(id);
            }
        }
    }