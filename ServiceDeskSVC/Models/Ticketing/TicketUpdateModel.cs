using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceDeskSVC.Models.Ticketing
{
    public class TicketUpdateModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        public int Type { get; set; }
        public DateTime? DueDate { get; set; }
        public string ResolutionComments { get; set; }
        [Required]
        public string AssignedToLoginName { get; set; }
        [Required]
        public string Category { get; set; }
    }
}