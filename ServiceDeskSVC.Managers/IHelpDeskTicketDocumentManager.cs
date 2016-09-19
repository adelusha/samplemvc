using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers
{
    public interface IHelpDeskTicketDocumentManager
    {
        List<HelpDesk_TicketDocuments_vm> GetAllDocumentsForTicket(int documentId);

        HelpDesk_TicketDocuments_vm GetSingleDocument(int documentId);

        int SaveDocument(HelpDesk_TicketDocuments_vm document);

        bool DeleteDocument(int documentID);        
    }
}
