using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
{
    public interface IHelpDeskTicketCommentRepository
    {
        List<HelpDesk_TicketComments> GetAllTicketComments(int ticketId);

        bool DeleteTicketCommentById(int id);

        int CreateTicketComment(int id, HelpDesk_TicketComments comment);

        int EditTicketCommentById(int id, HelpDesk_TicketComments comment);
    }
}
