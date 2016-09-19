using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers
{
    public interface IHelpDeskTicketTypeManager
    {
        List<HelpDesk_TicketType_vm> GetAllTicketTypes();

        bool DeleteTicketTypeById(int id);

        int CreateTicketType(HelpDesk_TicketType_vm type);

        int EditTicketTypeById(int id, HelpDesk_TicketType_vm type);        
    }
}
