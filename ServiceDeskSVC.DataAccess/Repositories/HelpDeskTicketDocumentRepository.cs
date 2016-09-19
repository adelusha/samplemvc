using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
{
    public class HelpDeskTicketDocumentRepository : IHelpDeskTicketDocumentRepository
    {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public HelpDeskTicketDocumentRepository(ServiceDeskContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<HelpDesk_TicketDocuments> GetAllDocumentsForTicket(int ticketId)
        {
            List<HelpDesk_TicketDocuments> allDocuments =
                _context.HelpDesk_TicketDocuments.Where(x => x.TicketID == ticketId).ToList();
            return allDocuments;
        }

        public HelpDesk_TicketDocuments GetSingleDocument(int documentId)
        {
            HelpDesk_TicketDocuments singleDoc =
                _context.HelpDesk_TicketDocuments.FirstOrDefault(x => x.Id == documentId);
            return singleDoc;
        }

        public int SaveDocument(HelpDesk_TicketDocuments document)
        {
            _context.HelpDesk_TicketDocuments.Add(document);
            _context.SaveChanges();
            return document.Id;
        }

        public bool DeleteDocument(int documentID)
        {
            try
            {
                HelpDesk_TicketDocuments doc = _context.HelpDesk_TicketDocuments.FirstOrDefault(x => x.Id == documentID);
                _context.HelpDesk_TicketDocuments.Remove(doc);
                _context.SaveChanges();
                _logger.Debug("Ticket documetn with id " + documentID + " was deleted.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }
    }
}
