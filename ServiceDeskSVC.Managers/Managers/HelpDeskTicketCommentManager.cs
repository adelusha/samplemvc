using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class HelpDeskTicketCommentManager:IHelpDeskTicketCommentManager
        {
        private readonly IHelpDeskTicketCommentRepository _helpDeskTicketCommentRepository;
        private readonly ILogger _logger;
        private readonly INSUserRepository _nsUserRepository;
        private readonly IHelpDeskTicketRepository _helpDeskTicketRepository;
        public HelpDeskTicketCommentManager(IHelpDeskTicketCommentRepository helpDeskCommentRepository,
            INSUserRepository nsUserRepository,
            IHelpDeskTicketRepository helpDeskTicketRepository,
            ILogger logger)
            {
            _helpDeskTicketCommentRepository = helpDeskCommentRepository;
            _logger = logger;
            _nsUserRepository = nsUserRepository;
            _helpDeskTicketRepository = helpDeskTicketRepository;
            }

        public List<HelpDesk_TicketComments_vm> GetAllTicketComments(int ticketNumber)
            {
            if(ticketNumber == 0)
                {
                throw new ArgumentOutOfRangeException("TicketId cannot be 0.");
                }
            HelpDesk_Tickets relatedTicket = _helpDeskTicketRepository.GetTicketByID(ticketNumber);
            var allComments = _helpDeskTicketCommentRepository.GetAllTicketComments(relatedTicket.Id);
            if(allComments == null)
                {
                _logger.Warn("There are no comments for the ticket.");
                }

            return allComments.Select(mapEntityToViewModelTicketComments).ToList();
            }

        public bool DeleteTicketCommentById(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _helpDeskTicketCommentRepository.DeleteTicketCommentById(id);
            }

        public int CreateTicketComment(int ticketId, HelpDesk_TicketComments_vm comment)
            {
            if(ticketId == 0)
                {
                throw new ArgumentOutOfRangeException("TicketId cannot be 0.");
                }

            return _helpDeskTicketCommentRepository.CreateTicketComment(ticketId,
                mapViewModelToEntityTicketComments(comment));
            }

        public int EditTicketCommentById(int id, HelpDesk_TicketComments_vm comment)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _helpDeskTicketCommentRepository.EditTicketCommentById(id,
                mapViewModelToEntityTicketComments(comment));
            }

        private HelpDesk_TicketComments_vm mapEntityToViewModelTicketComments(HelpDesk_TicketComments EFTicketComment)
            {
            return new HelpDesk_TicketComments_vm
            {
                Id = EFTicketComment.Id,
                Comment = EFTicketComment.Comment,
                CommentDateTime = EFTicketComment.CommentDateTime,
                CommentTypeID = EFTicketComment.CommentTypeID,
                TicketID = EFTicketComment.TicketID,
                AuthorUserName = EFTicketComment.ServiceDesk_Users == null ? null : EFTicketComment.ServiceDesk_Users.UserName,
                AuthorUser = EFTicketComment.ServiceDesk_Users == null ? null : new Comment_User()
                {
                    UserName = EFTicketComment.ServiceDesk_Users.UserName,
                    DisplayName = EFTicketComment.ServiceDesk_Users.FirstName + " " + EFTicketComment.ServiceDesk_Users.LastName
                }
            };
            }

        private HelpDesk_TicketComments mapViewModelToEntityTicketComments(HelpDesk_TicketComments_vm VMTicketComment)
            {
            ServiceDesk_Users assignedTo = _nsUserRepository.GetUserByUserName(VMTicketComment.AuthorUserName);
            HelpDesk_Tickets relatedTicket = _helpDeskTicketRepository.GetTicketByID(VMTicketComment.TicketID);
            return new HelpDesk_TicketComments
            {
                Id = VMTicketComment.Id,
                Author = assignedTo.Id,
                Comment = VMTicketComment.Comment,
                CommentDateTime = DateTime.UtcNow,
                CommentTypeID = VMTicketComment.CommentTypeID,
                TicketID = relatedTicket.Id
            };
            }
        }
    }
