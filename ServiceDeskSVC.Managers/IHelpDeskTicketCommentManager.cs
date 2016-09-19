using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers
{
    public interface IHelpDeskTicketCommentManager
    {
        List<HelpDesk_TicketComments_vm> GetAllTicketComments(int ticketId);

        bool DeleteTicketCommentById(int id);

        int CreateTicketComment(int ticketId, HelpDesk_TicketComments_vm comment);

        int EditTicketCommentById(int id, HelpDesk_TicketComments_vm comment);        
    }
}
