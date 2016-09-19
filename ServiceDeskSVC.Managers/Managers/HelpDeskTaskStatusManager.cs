using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tasks;


namespace ServiceDeskSVC.Managers.Managers
    {
    public class HelpDeskTaskStatusManager:IHelpDeskTaskStatusManager
        {
        private readonly IHelpDeskTasksStatusRepository _helpDeskTaskStatusRepository;
        private readonly ILogger _logger;

        public HelpDeskTaskStatusManager(IHelpDeskTasksStatusRepository helpDeskTaskStatusRepository, ILogger logger)
            {
            _helpDeskTaskStatusRepository = helpDeskTaskStatusRepository;
            _logger = logger;
            }

        public List<HelpDesk_TaskStatus_vm> GetAllTaskStatuses()
            {
            var allStatuses = _helpDeskTaskStatusRepository.GetAllTaskStatuses();
            return allStatuses.Select(mapEntityToViewModelTaskStatus).ToList();
            }

        public bool DeleteTaskStatusById(int id)
            {
            if(id < 1)
                {
                throw new ArgumentOutOfRangeException("Id cannot be less than 1.");
                }
            return _helpDeskTaskStatusRepository.DeleteTaskStatus(id);
            }

        public int CreateTaskStatus(HelpDesk_TaskStatus_vm status)
            {
            return _helpDeskTaskStatusRepository.CreateTaskStatus(mapViewModelToEntityTaskStatus(status));
            }

        public int EditTaskStatusById(int id, HelpDesk_TaskStatus_vm status)
            {
            if(id < 1)
                {
                throw new ArgumentOutOfRangeException("Id cannot be less than 1.");
                }
            return _helpDeskTaskStatusRepository.EditTaskStatus(id, mapViewModelToEntityTaskStatus(status));
            }

        private HelpDesk_TaskStatus_vm mapEntityToViewModelTaskStatus(HelpDesk_TaskStatus EFTaskStatus)
            {
            _logger.Debug("Mapping Entity to Task Status View Model.");
            return new HelpDesk_TaskStatus_vm
            {
                Id = EFTaskStatus.Id,
                Status = EFTaskStatus.Status
            };
            }

        private HelpDesk_TaskStatus mapViewModelToEntityTaskStatus(HelpDesk_TaskStatus_vm VMTaskStatus)
            {
            return new HelpDesk_TaskStatus
            {
                Id = VMTaskStatus.Id ?? 0,
                Status = VMTaskStatus.Status
            };
            }
        }
    }
