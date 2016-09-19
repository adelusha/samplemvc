using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
{
    public class HelpDeskTicketStatusRepository : IHelpDeskTicketStatusRepository
    {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public HelpDeskTicketStatusRepository(ServiceDeskContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<HelpDesk_TicketStatus> GetAllStatuses()
        {
            List<HelpDesk_TicketStatus> allStatuses = _context.HelpDesk_TicketStatus.ToList(); 
            return allStatuses;
        }

        public bool DeleteStatusById(int id)
        {
            bool result = false;
            try
            {
                HelpDesk_TicketStatus oldStatus = _context.HelpDesk_TicketStatus.FirstOrDefault(x => x.Id == id);
                _context.HelpDesk_TicketStatus.Remove(oldStatus);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return result;
        }


        public int CreateStatus(HelpDesk_TicketStatus status)
        {
            _context.HelpDesk_TicketStatus.Add(status);
            _context.SaveChanges();
            return status.Id;
        }


        public int EditStatusById(int id, HelpDesk_TicketStatus status)
        {
            try
            {
                HelpDesk_TicketStatus oldStatus = _context.HelpDesk_TicketStatus.FirstOrDefault(x => x.Id == status.Id);
                if(oldStatus != null) oldStatus.Status = status.Status;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }
            return status.Id;
        }
    }
}
