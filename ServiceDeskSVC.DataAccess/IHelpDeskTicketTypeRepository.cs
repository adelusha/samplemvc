using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
{
    public interface IHelpDeskTicketTypeRepository
    {
        List<HelpDesk_TicketType> GetAllTicketTypes();

        bool DeleteTicketTypeById(int id);

        int CreateTicketType(HelpDesk_TicketType type);

        int EditTicketTypeById(int id, HelpDesk_TicketType type);
    }
}
