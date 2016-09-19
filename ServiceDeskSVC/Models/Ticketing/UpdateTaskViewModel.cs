using System.ComponentModel.DataAnnotations;
using ServiceDesk.Ticketing.Domain.UserAggregate;

namespace ServiceDeskSVC.Models.Ticketing
{
    public class UpdateTaskViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public string AssignedTo { get; set; }
    }
}