using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
    {
    public class HelpDeskTicketCategoryRepository:IHelpDeskTicketCategoryRepository
        {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public HelpDeskTicketCategoryRepository(ServiceDeskContext context, ILogger logger)
            {
            _context = context;
            _logger = logger;
            }

        public List<HelpDesk_TicketCategory> GetAllCategories()
            {
            List<HelpDesk_TicketCategory> allCategories = _context.HelpDesk_TicketCategory.ToList();
            return allCategories;
            }

        public bool DeleteCategoryById(int id)
            {
            bool result = false;
            try
                {
                HelpDesk_TicketCategory oldCategory = _context.HelpDesk_TicketCategory.FirstOrDefault(x => x.Id == id);
                _context.HelpDesk_TicketCategory.Remove(oldCategory);
                _context.SaveChanges();
                result = true;
                _logger.Info("Ticket category with id " + id + " was deleted.");
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return result;
            }

        public int CreateCategory(HelpDesk_TicketCategory category)
            {
            _context.HelpDesk_TicketCategory.Add(category);
            _context.SaveChanges();
            return category.Id;
            }


        public int EditCategoryById(int id, HelpDesk_TicketCategory category)
            {
            try
            {
                HelpDesk_TicketCategory oldCategory =
                    _context.HelpDesk_TicketCategory.FirstOrDefault(x => x.Id == category.Id);
                if(oldCategory != null) oldCategory.Category = category.Category;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }

            return category.Id;
            }
        }
    }
