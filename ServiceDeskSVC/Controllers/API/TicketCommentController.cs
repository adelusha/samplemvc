using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API
    {
    public class TicketCommentController:ApiController
        {
        private readonly IHelpDeskTicketCommentManager _helpDeskTicketCommentManager;
        private readonly ILogger _logger;

        public TicketCommentController(IHelpDeskTicketCommentManager helpDeskTicketCommentManager, ILogger logger)
            {
            _helpDeskTicketCommentManager = helpDeskTicketCommentManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public List<HelpDesk_TicketComments_vm> Get(int id)
            {
            _logger.Info("Getting all comments for ticket with id " + id);
            return _helpDeskTicketCommentManager.GetAllTicketComments(id);
            }

        /// <summary>
        /// Posts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post(int id, [FromBody]HelpDesk_TicketComments_vm value)
            {
            _logger.Info("Adding a new comment for ticket with id " + id);
            return _helpDeskTicketCommentManager.CreateTicketComment(id, value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]HelpDesk_TicketComments_vm value)
            {
            _logger.Info("Editing the comment with id " + id);
            return _helpDeskTicketCommentManager.EditTicketCommentById(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the comment with id " + id);
            return _helpDeskTicketCommentManager.DeleteTicketCommentById(id);
            }
        }
    }