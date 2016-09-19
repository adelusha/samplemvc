using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
{
    public interface IHelpDeskTicketStatusRepository
    {
        List<HelpDesk_TicketStatus> GetAllStatuses();

        bool DeleteStatusById(int id);

        int CreateStatus(HelpDesk_TicketStatus status);

        int EditStatusById(int id, HelpDesk_TicketStatus status);
    }
}
