using System;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tasks
{
    public class HelpDesk_Tasks_View_vm
    {
    public int? Id { get; set; }
    public int? TicketID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public DateTime? StatusChangedDateTime { get; set; }
    public string AssignedTo { get; set; }    
    }
}
