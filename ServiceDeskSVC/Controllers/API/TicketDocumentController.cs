using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API
    {
    public class TicketDocumentController:ApiController
        {
        private readonly IHelpDeskTicketDocumentManager _helpDeskTicketDocumentManager;
        private readonly ILogger _logger;

        public TicketDocumentController(IHelpDeskTicketDocumentManager helpDeskTicketDocumentManager, ILogger logger)
            {
            _helpDeskTicketDocumentManager = helpDeskTicketDocumentManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public HelpDesk_TicketDocuments_vm Get(int id)
            {
            _logger.Info("Getting single document with id " + id);
            return _helpDeskTicketDocumentManager.GetSingleDocument(id);
            }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IEnumerable<HelpDesk_TicketDocuments_vm> GetAll(int TicketId)
            {
            _logger.Info("Getting all documetns for ticket with id "+TicketId);
            return _helpDeskTicketDocumentManager.GetAllDocumentsForTicket(TicketId);
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]HelpDesk_TicketDocuments_vm value)
            {
            _logger.Info("Adding a new document.");
            return _helpDeskTicketDocumentManager.SaveDocument(value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting document with id " + id);
            return _helpDeskTicketDocumentManager.DeleteDocument(id);
            }
        }
    }