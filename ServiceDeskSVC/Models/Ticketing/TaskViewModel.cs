using System;

namespace ServiceDeskSVC.Controllers.API.Ticketing
{
    public class TaskViewModel
    {
        public int TaskNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AssignedTo { get; set; }
     }
}