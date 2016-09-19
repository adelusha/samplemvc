using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers
{
    public interface IHelpDeskTicketStatusManager
    {
        List<HelpDesk_TicketStatus_vm> GetAllStatuses();

        bool DeleteStatusById(int id);

        int CreateStatus(HelpDesk_TicketStatus_vm status);

        int EditStatusById(int id, HelpDesk_TicketStatus_vm status);
    }
}
