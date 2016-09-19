using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers
{
    public interface IHelpDeskTicketManager
    {
        List<HelpDesk_Tickets_View_vm> GetAllTickets();

        HelpDesk_Tickets_vm GetTicketByID(int id);

        List<HelpDesk_Tickets_View_vm> GetTicketsByUser(string userName);

        List<HelpDesk_Tickets_View_vm> GetTicketsByDepartment(int departmentID);

        int CreateTicket(HelpDesk_Tickets_vm ticket);

        int CreateSimpleTicket(HelpDesk_Tickets_SimplePost_vm ticket);

        int EditTicket(int id, HelpDesk_Tickets_vm ticket);
    }
}
