using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
    {
    public class HelpDeskTicketTypeRepository:IHelpDeskTicketTypeRepository
        {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public HelpDeskTicketTypeRepository(ServiceDeskContext context, ILogger logger)
            {
            _context = context;
            _logger = logger;
            }

        public List<HelpDesk_TicketType> GetAllTicketTypes()
            {
            List<HelpDesk_TicketType> allTypes = _context.HelpDesk_TicketType.ToList();
            return allTypes;
            }

        public bool DeleteTicketTypeById(int id)
            {
            bool result = false;
            try
                {
                HelpDesk_TicketType oldType = _context.HelpDesk_TicketType.FirstOrDefault(x => x.Id == id);
                _context.HelpDesk_TicketType.Remove(oldType);
                _context.SaveChanges();
                result = true;
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return result;
            }


        public int CreateTicketType(HelpDesk_TicketType type)
            {
            _context.HelpDesk_TicketType.Add(type);
            _context.SaveChanges();
            return type.Id;
            }


        public int EditTicketTypeById(int id, HelpDesk_TicketType type)
            {
            try
            {
                HelpDesk_TicketType oldType = _context.HelpDesk_TicketType.FirstOrDefault(x => x.Id == type.Id);
                if(oldType != null) oldType.TicketType = type.TicketType;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }

            return type.Id;
            }
        }
    }
