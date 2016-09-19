using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class HelpDeskTicketCategoryManager:IHelpDeskTicketCategoryManager
        {
        private readonly IHelpDeskTicketCategoryRepository _helpDeskTicketCategoryRepository;
        private readonly ILogger _logger;

        public HelpDeskTicketCategoryManager(IHelpDeskTicketCategoryRepository helpDeskCategoryRepository, ILogger logger)
            {
            _helpDeskTicketCategoryRepository = helpDeskCategoryRepository;
            _logger = logger;
            }


        public List<HelpDesk_TicketCategory_vm> GetAllCategories()
            {
            var allCats = _helpDeskTicketCategoryRepository.GetAllCategories();
            if(allCats == null)
                {
                _logger.Info("There are no categories.");
                }

            return allCats.Select(mapEntityToViewModelTicketCategory).ToList();
            }

        public bool DeleteCategoryById(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }
            return _helpDeskTicketCategoryRepository.DeleteCategoryById(id);
            }

        public int CreateCategory(HelpDesk_TicketCategory_vm category)
            {
            return _helpDeskTicketCategoryRepository.CreateCategory(mapViewModelToEntityTicketCategory(category));
            }

        public int EditCategoryById(int id, HelpDesk_TicketCategory_vm category)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }
            return _helpDeskTicketCategoryRepository.EditCategoryById(id, mapViewModelToEntityTicketCategory(category));
            }

        private HelpDesk_TicketCategory_vm mapEntityToViewModelTicketCategory(HelpDesk_TicketCategory EFTicketCat)
            {
            return new HelpDesk_TicketCategory_vm
            {
                Id = EFTicketCat.Id,
                Category = EFTicketCat.Category
            };
            }

        private HelpDesk_TicketCategory mapViewModelToEntityTicketCategory(HelpDesk_TicketCategory_vm VMTicketCat)
            {
            return new HelpDesk_TicketCategory
            {
                Id = VMTicketCat.Id ?? 0,
                Category = VMTicketCat.Category
            };
            }
        }
    }
