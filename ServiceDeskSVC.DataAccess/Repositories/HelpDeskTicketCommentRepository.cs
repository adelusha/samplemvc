using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
    {
    public class HelpDeskTicketCommentRepository:IHelpDeskTicketCommentRepository
        {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public HelpDeskTicketCommentRepository(ServiceDeskContext context, ILogger logger)
            {
            _context = context;
            _logger = logger;
            }

        public List<HelpDesk_TicketComments> GetAllTicketComments(int ticketId)
            {
            List<HelpDesk_TicketComments> allComments = _context.HelpDesk_TicketComments.Where(x => x.TicketID == ticketId).ToList();
            return allComments;
            }

        public bool DeleteTicketCommentById(int id)
            {
            bool result = false;
            try
                {
                HelpDesk_TicketComments oldComment = _context.HelpDesk_TicketComments.FirstOrDefault(x => x.Id == id);
                _context.HelpDesk_TicketComments.Remove(oldComment);
                _context.SaveChanges();
                result = true;
                _logger.Info("Ticket comment with id " + id + " was deleted.");
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return result;
            }

        public int CreateTicketComment(int id, HelpDesk_TicketComments comment)
            {
            _context.HelpDesk_TicketComments.Add(comment);
            _context.SaveChanges();
            return comment.Id;
            }

        public int EditTicketCommentById(int id, HelpDesk_TicketComments comment)
            {
            try
            {
                HelpDesk_TicketComments oldComment =
                    _context.HelpDesk_TicketComments.FirstOrDefault(x => x.Id == comment.Id);
                if(oldComment != null)
                {
                    oldComment.Comment = comment.Comment;
                }
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }

            return comment.Id;
            }

        }
    }
