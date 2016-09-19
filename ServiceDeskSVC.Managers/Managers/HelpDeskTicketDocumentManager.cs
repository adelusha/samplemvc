using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class HelpDeskTicketDocumentManager:IHelpDeskTicketDocumentManager
        {
        private readonly IHelpDeskTicketDocumentRepository _helpDeskTicketDocumentRepository;
        private readonly ILogger _logger;

        public HelpDeskTicketDocumentManager(IHelpDeskTicketDocumentRepository helpDeskTicketDocumentRepository, ILogger logger)
            {
            _helpDeskTicketDocumentRepository = helpDeskTicketDocumentRepository;
            _logger = logger;
            }

        public List<HelpDesk_TicketDocuments_vm> GetAllDocumentsForTicket(int ticketId)
            {
            if(ticketId == 0)
                {
                throw new ArgumentOutOfRangeException("TicketId cannot be 0.");
                }

            var allDocsForTicket = _helpDeskTicketDocumentRepository.GetAllDocumentsForTicket(ticketId);
            if(allDocsForTicket == null)
                {
                _logger.Info("There are no documents for specified ticket.");
                }

            return allDocsForTicket.Select(mapEntityToViewModelTicketDocuments).ToList();
            }

        public HelpDesk_TicketDocuments_vm GetSingleDocument(int Id)
            {
            if(Id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            var singleDocument = _helpDeskTicketDocumentRepository.GetSingleDocument(Id);
            return mapEntityToViewModelTicketDocuments(singleDocument);
            }

        public int SaveDocument(HelpDesk_TicketDocuments_vm document)
            {
            return _helpDeskTicketDocumentRepository.SaveDocument(mapViewModelToEntityTicketDocuments(document));
            }

        public bool DeleteDocument(int documentID)
            {
            if(documentID == 0)
                {
                throw new ArgumentOutOfRangeException("DocumentID cannot be 0.");
                }

            return _helpDeskTicketDocumentRepository.DeleteDocument(documentID);
            }

        private HelpDesk_TicketDocuments_vm mapEntityToViewModelTicketDocuments(HelpDesk_TicketDocuments EFTicketDocument)
            {
            return new HelpDesk_TicketDocuments_vm
            {
                DocumentPath = EFTicketDocument.DocumentPath,
                Id = EFTicketDocument.Id,
                TicketID = EFTicketDocument.TicketID
            };
            }

        private HelpDesk_TicketDocuments mapViewModelToEntityTicketDocuments(HelpDesk_TicketDocuments_vm VMTicketDocument)
            {
            return new HelpDesk_TicketDocuments
            {
                DocumentPath = VMTicketDocument.DocumentPath,
                Id = VMTicketDocument.Id ?? 0,
                TicketID = VMTicketDocument.TicketID
            };
            }
        }
    }
