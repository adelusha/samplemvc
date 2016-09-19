using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tasks;

namespace ServiceDeskSVC.Managers
{
    public interface IHelpDeskTaskManager
        {
        List<HelpDesk_Tasks_View_vm> GetAllTasks();

        HelpDesk_Tasks_vm GetTaskById(int id);

        List<HelpDesk_Tasks_View_vm> GetTasksByUser(string userName);

        List<HelpDesk_Tasks_View_vm> GetTasksByTicketId(int id); 

        int CreateTask(HelpDesk_Tasks_vm task);

        int EditTask(int id, HelpDesk_Tasks_vm task);

        bool DeleteTask(int id);
    }
}
