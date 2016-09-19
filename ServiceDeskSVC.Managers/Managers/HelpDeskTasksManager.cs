using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tasks;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class HelpDeskTaskManager:IHelpDeskTaskManager
        {
        private readonly IHelpDeskTasksRepository _helpDeskTasksRepository;
        private readonly ILogger _logger;
        private readonly INSUserRepository _nsUserRepository;
        public HelpDeskTaskManager(IHelpDeskTasksRepository helpDeskTasksRepository, INSUserRepository nsUserRepository, ILogger logger)
        {
            _nsUserRepository = nsUserRepository;
            _helpDeskTasksRepository = helpDeskTasksRepository;
            _logger = logger;
            }

        private HelpDesk_Tasks_View_vm mapEntityToViewModelTask(HelpDesk_Tasks EFTask)
            {
            _logger.Debug("Mapping Entity to Task View Model.");
            var vmT = new HelpDesk_Tasks_View_vm
                {
                    Id = EFTask.Id,
                    Title = EFTask.Title,
                    TicketID = EFTask.TicketID,
                    Description = EFTask.Description,
                    Status = EFTask.HelpDesk_TaskStatus.Status,
                    CreatedDateTime = EFTask.CreatedDateTime,
                    StatusChangedDateTime = EFTask.StatusChangedDateTime,
                    AssignedTo = EFTask.ServiceDesk_Users == null ? "" : (EFTask.ServiceDesk_Users.FirstName + " " + EFTask.ServiceDesk_Users.LastName),
                };

            return vmT;
            }

        private HelpDesk_Tasks_vm mapEntityToViewModelSingleTask(HelpDesk_Tasks EFTask)
        {
            _logger.Debug("Mapping Entity to Task View Model.");
                var vmT = new HelpDesk_Tasks_vm
                {
                    Id = EFTask.Id,
                    Title = EFTask.Title,
                    TicketID = EFTask.TicketID,
                    Description = EFTask.Description,
                    StatusID = EFTask.StatusID,
                    CreatedDateTime = EFTask.CreatedDateTime,
                    StatusChangedDateTime = EFTask.StatusChangedDateTime,
                    AssignedToUserName = EFTask.ServiceDesk_Users == null ? null : EFTask.ServiceDesk_Users.UserName,
                    ServiceDesk_Users_AssignedTo = EFTask.ServiceDesk_Users == null ? null : new Task_User()
                    {
                        SID = EFTask.ServiceDesk_Users.SID,
                        UserName = EFTask.ServiceDesk_Users.UserName,
                        DisplayName = EFTask.ServiceDesk_Users.FirstName + " " + EFTask.ServiceDesk_Users.LastName
                    }
                };

                return vmT;
        }

        private HelpDesk_Tasks mapViewModelToEntityTask(HelpDesk_Tasks_vm VMTask)
            {
            ServiceDesk_Users assignedTo = _nsUserRepository.GetUserByUserName(VMTask.AssignedToUserName);
            var tasks = new HelpDesk_Tasks
                {

                    Id = VMTask.Id,
                    TicketID = VMTask.TicketID,
                    Title = VMTask.Title,
                    Description = VMTask.Description,
                    StatusID = VMTask.StatusID,
                    CreatedDateTime = VMTask.CreatedDateTime,
                    StatusChangedDateTime = VMTask.StatusChangedDateTime,
                    AssignedTo = assignedTo.Id
                };

            return tasks;
            }

        public List<HelpDesk_Tasks_View_vm> GetAllTasks()
            {
            var allTasks = _helpDeskTasksRepository.GetAllTasks();
            return allTasks.Select(mapEntityToViewModelTask).ToList();
            }

        public HelpDesk_Tasks_vm GetTaskById(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            var taskById = _helpDeskTasksRepository.GetTaskById(id);
            if(taskById == null)
            {
                _logger.Warn("No task with the specified id was found.");
            }

            return mapEntityToViewModelSingleTask(taskById);
            }

        public List<HelpDesk_Tasks_View_vm> GetTasksByUser(string userName)
            {
            if(string.IsNullOrEmpty(userName))
                {
                throw new ArgumentNullException("UserName cannot be empty.");
                }

            var taskByUser = _helpDeskTasksRepository.GetTasksByUser(userName);
            if(taskByUser == null)
            {
                _logger.Warn("There are no tasks for the specified user.");
            }

            return taskByUser.Select(mapEntityToViewModelTask).ToList();
            }

        public List<HelpDesk_Tasks_View_vm> GetTasksByTicketId(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            var taskByTicketId = _helpDeskTasksRepository.GetTasksByTicketId(id);
            return taskByTicketId.Select(mapEntityToViewModelTask).ToList();
            }

        public int CreateTask(HelpDesk_Tasks_vm task)
            {
            return _helpDeskTasksRepository.CreateTask(mapViewModelToEntityTask(task));
            }

        public int EditTask(int id, HelpDesk_Tasks_vm task)
            {
            return _helpDeskTasksRepository.EditTask(id, mapViewModelToEntityTask(task));
            }

        public bool DeleteTask(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _helpDeskTasksRepository.DeleteTask(id);
            }
        }
    }
