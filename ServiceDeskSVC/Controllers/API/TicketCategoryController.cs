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
    public class TicketCategoryController:ApiController
        {
        private readonly IHelpDeskTicketCategoryManager _helpDeskTicketCategoryManager;
        private readonly ILogger _logger;

        public TicketCategoryController(IHelpDeskTicketCategoryManager helpDeskTicketCategoryManager, ILogger logger)
            {
            _helpDeskTicketCategoryManager = helpDeskTicketCategoryManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HelpDesk_TicketCategory_vm> Get()
            {
            _logger.Info("Getting all ticket categories.");
            return _helpDeskTicketCategoryManager.GetAllCategories();
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]HelpDesk_TicketCategory_vm value)
            {
            _logger.Info("Creating a new ticket category.");
            return _helpDeskTicketCategoryManager.CreateCategory(value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]HelpDesk_TicketCategory_vm value)
            {
            _logger.Info("Editing the ticket category with id "+id);
            return _helpDeskTicketCategoryManager.EditCategoryById(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the ticket category with id"+id);
            return _helpDeskTicketCategoryManager.DeleteCategoryById(id);
            }
        }
    }