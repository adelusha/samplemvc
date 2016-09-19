using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
    {
    public interface IHelpDeskTasksRepository
        {
        List<HelpDesk_Tasks> GetAllTasks();

        HelpDesk_Tasks GetTaskById(int id);

        List<HelpDesk_Tasks> GetTasksByUser(string userName);

        List<HelpDesk_Tasks> GetTasksByTicketId(int id);
 
        int CreateTask(HelpDesk_Tasks task);

        int EditTask(int id, HelpDesk_Tasks task);

        bool DeleteTask(int id);
        }
    }
