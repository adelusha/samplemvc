using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
{
    public interface IHelpDeskTicketRepository
    {
        List<HelpDesk_Tickets> GetAllTickets();

        HelpDesk_Tickets GetTicketByID(int id);

        List<HelpDesk_Tickets> GetTicketsByUser(string userName);

        List<HelpDesk_Tickets> GetTicketsByDepartment(int departmentID);

        int CreateTicket(HelpDesk_Tickets ticket);

        int EditTicket(int id, HelpDesk_Tickets ticket);
    }
}
