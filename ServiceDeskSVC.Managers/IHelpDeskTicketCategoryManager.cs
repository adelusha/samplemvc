using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers
{
    public interface IHelpDeskTicketCategoryManager
    {
        List<HelpDesk_TicketCategory_vm> GetAllCategories();

        bool DeleteCategoryById(int id);

        int CreateCategory(HelpDesk_TicketCategory_vm category);

        int EditCategoryById(int id, HelpDesk_TicketCategory_vm category);
    }
}
