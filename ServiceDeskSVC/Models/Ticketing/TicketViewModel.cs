using System;

namespace ServiceDeskSVC.Models.Ticketing
{
    public class TicketViewModel
    {
        public int TicketNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requestor_DisplayName { get; set; }
        public string Requestor_Departament { get; set; }
        public string Requestor_Location { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Category { get; set; }
        public int TypeNo { get; set; }
        public string Type { get; set; }
        public int PriorityNo { get; set; }
        public string Priority { get; set; }
        public int StatusNo { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
        public string AssignedToLoginName { get; set; }
        public string ResolutionComments { get; set; }
    }
}