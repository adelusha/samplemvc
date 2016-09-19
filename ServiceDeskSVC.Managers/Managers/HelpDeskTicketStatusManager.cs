using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class HelpDeskTicketStatusManager:IHelpDeskTicketStatusManager
        {
        private readonly IHelpDeskTicketStatusRepository _helpDeskTicketStatusRepository;
        private readonly ILogger _logger;

        public HelpDeskTicketStatusManager(IHelpDeskTicketStatusRepository helpDeskStatusRepository, ILogger logger)
            {
            _helpDeskTicketStatusRepository = helpDeskStatusRepository;
            _logger = logger;
            }


        public List<HelpDesk_TicketStatus_vm> GetAllStatuses()
            {
            var allStatuses = _helpDeskTicketStatusRepository.GetAllStatuses();
            if(allStatuses == null)
                {
                _logger.Warn("There aren't any ticket statuses.");
                }

            return allStatuses.Select(mapEntityToViewModelTicketStatus).ToList();
            }

        public bool DeleteStatusById(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _helpDeskTicketStatusRepository.DeleteStatusById(id);
            }

        public int CreateStatus(HelpDesk_TicketStatus_vm status)
            {
            return _helpDeskTicketStatusRepository.CreateStatus(mapViewModelToEntityTicketStatus(status));
            }

        public int EditStatusById(int id, HelpDesk_TicketStatus_vm status)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _helpDeskTicketStatusRepository.EditStatusById(id, mapViewModelToEntityTicketStatus(status));
            }

        private HelpDesk_TicketStatus_vm mapEntityToViewModelTicketStatus(HelpDesk_TicketStatus EFTicketStatus)
            {
            return new HelpDesk_TicketStatus_vm
            {
                Id = EFTicketStatus.Id,
                Status = EFTicketStatus.Status
            };
            }

        private HelpDesk_TicketStatus mapViewModelToEntityTicketStatus(HelpDesk_TicketStatus_vm VMTicketStatus)
            {
            return new HelpDesk_TicketStatus
            {
                Id = VMTicketStatus.Id ?? 0,
                Status = VMTicketStatus.Status
            };
            }
        }
    }
