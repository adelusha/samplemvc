using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
{
    public interface IHelpDeskTicketCategoryRepository
    {
        List<HelpDesk_TicketCategory> GetAllCategories();

        bool DeleteCategoryById(int id);

        int CreateCategory(HelpDesk_TicketCategory category);

        int EditCategoryById(int id, HelpDesk_TicketCategory category);
    }
}
