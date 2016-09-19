using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
    {
    public interface IHelpDeskTasksStatusRepository
    {

        List<HelpDesk_TaskStatus> GetAllTaskStatuses();

        bool DeleteTaskStatus(int id);

        int CreateTaskStatus(HelpDesk_TaskStatus taskStatus);

        int EditTaskStatus(int id, HelpDesk_TaskStatus taskStatus);

        }
    }
