using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
{
    public interface IHelpDeskTicketDocumentRepository
    {
        List<HelpDesk_TicketDocuments> GetAllDocumentsForTicket(int ticketId);

        HelpDesk_TicketDocuments GetSingleDocument(int documentId);

        int SaveDocument(HelpDesk_TicketDocuments document);

        bool DeleteDocument(int documentID);
    }
}
