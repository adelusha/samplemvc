using System;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets
{
    public class HelpDesk_Tickets_SimplePost_vm
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string RequestorUserName { get; set; }

        public string Location { get; set; }

        public string Department { get; set; }

        public DateTime? RequestedDueDate { get; set; }

        public int TicketCategoryID { get; set; }

    }
}
