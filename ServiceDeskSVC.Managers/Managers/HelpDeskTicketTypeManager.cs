using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class HelpDeskTicketTypeManager:IHelpDeskTicketTypeManager
        {
        private readonly IHelpDeskTicketTypeRepository _helpDeskTicketTypeRepository;
        private readonly ILogger _logger;

        public HelpDeskTicketTypeManager(IHelpDeskTicketTypeRepository helpDeskTicketTypeRepository, ILogger logger)
            {
            _helpDeskTicketTypeRepository = helpDeskTicketTypeRepository;
            _logger = logger;
            }

        public List<HelpDesk_TicketType_vm> GetAllTicketTypes()
            {
            var allTypes = _helpDeskTicketTypeRepository.GetAllTicketTypes();
            if(allTypes == null || allTypes.Count == 0)
                {
                _logger.Warn("There are no ticket types.");
                }

            return allTypes.Select(mapEntityToViewModelTicketType).ToList();
            }

        public bool DeleteTicketTypeById(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _helpDeskTicketTypeRepository.DeleteTicketTypeById(id);
            }

        public int CreateTicketType(HelpDesk_TicketType_vm type)
            {
            return _helpDeskTicketTypeRepository.CreateTicketType(mapViewModelToEntityTicketType(type));
            }

        public int EditTicketTypeById(int id, HelpDesk_TicketType_vm type)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _helpDeskTicketTypeRepository.EditTicketTypeById(id, mapViewModelToEntityTicketType(type));
            }

        private HelpDesk_TicketType_vm mapEntityToViewModelTicketType(HelpDesk_TicketType EFTicketType)
            {
            return new HelpDesk_TicketType_vm
            {
                Id = EFTicketType.Id,
                TicketType = EFTicketType.TicketType
            };
            }

        private HelpDesk_TicketType mapViewModelToEntityTicketType(HelpDesk_TicketType_vm VMTicketType)
            {
            return new HelpDesk_TicketType
            {
                Id = VMTicketType.Id ?? 0,
                TicketType = VMTicketType.TicketType
            };
            }
        }
    }
