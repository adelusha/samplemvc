using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tasks;

namespace ServiceDeskSVC.Managers
{
    public interface IHelpDeskTaskStatusManager
    {
        List<HelpDesk_TaskStatus_vm> GetAllTaskStatuses();

        bool DeleteTaskStatusById(int id);

        int CreateTaskStatus(HelpDesk_TaskStatus_vm status);

        int EditTaskStatusById(int id, HelpDesk_TaskStatus_vm status);

    }
}
