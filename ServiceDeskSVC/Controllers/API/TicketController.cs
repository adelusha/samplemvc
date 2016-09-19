using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Web.Http;
using CommonUtilities;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API
    {
    public class TicketController:ApiController
        {
        private readonly IHelpDeskTicketManager _helpDeskTicketManager;
        private readonly ILogger _logger;
        public TicketController(IHelpDeskTicketManager helpDeskTicketManager, ILogger logger)
            {
            _helpDeskTicketManager = helpDeskTicketManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HelpDesk_Tickets_View_vm> Get()
            {
            _logger.Info("Getting all tickets. ");
            return _helpDeskTicketManager.GetAllTickets();
            }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public HelpDesk_Tickets_vm Get(int id)
            {
            _logger.Info("Getting ticket with id "+id);
            return _helpDeskTicketManager.GetTicketByID(id);
            }

        /// <summary>
        /// Gets tickets the by user. If user is IT returns tickets; if it's a normal user returns all related tickets.
        /// </summary>
        /// <param name="userName">Name of the user - samAccountName </param>
        /// <returns></returns>
        public IEnumerable<HelpDesk_Tickets_View_vm> GetByUser(string userName)
            {
            _logger.Info("Getting all tickets for user " + userName);
            Principal user = NSActiveDirectory.GetUser(userName);
            if(user == null)
            {
                throw new ArgumentNullException("Did not find any user with specified login name.");
            }

            GroupPrincipal group = NSActiveDirectory.GetGroup(CommonConstants.ITAdminGroup);
            if(user.IsMemberOf(group))
                {
                // if user is an IT admin return all tickets
                _logger.Debug("User is an IT admin.");
                return _helpDeskTicketManager.GetAllTickets();
                }
            else
                {
                _logger.Debug("User is a normal user.");
                // if a normal user return only tickets related to the current user
                return _helpDeskTicketManager.GetTicketsByUser(userName);
                }            
            }

        /// <summary>
        /// Gets the by department.
        /// </summary>
        /// <param name="departmentID">The department identifier.</param>
        /// <returns></returns>
        public IEnumerable<HelpDesk_Tickets_View_vm> GetByDepartment(int departmentID)
            {
            _logger.Info("Getting all tickets for department with id"+ departmentID);
            return _helpDeskTicketManager.GetTicketsByDepartment(departmentID);
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]HelpDesk_Tickets_vm value)
            {
            _logger.Info("Adding a new Simple ticket. ");
            return _helpDeskTicketManager.CreateTicket(value);
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [Route("api/Ticket/SimpleTicket")]
        public int PostSimpleValue([FromBody]HelpDesk_Tickets_SimplePost_vm value)
        {
            _logger.Info("Adding a new ticket. ");
            return _helpDeskTicketManager.CreateSimpleTicket(value);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]HelpDesk_Tickets_vm value)
            {
            _logger.Info("Editing the ticket with id "+id);
            return _helpDeskTicketManager.EditTicket(id, value);
            }
        }
    }