using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets
{
    public class HelpDesk_TicketDocuments_vm
    {
        public int? Id { get; set; }
        public string DocumentPath { get; set; }
        public int TicketID { get; set; }
    }
}
