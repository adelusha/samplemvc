using System.ComponentModel.DataAnnotations;

namespace ServiceDeskSVC.Models.Ticketing
{
    public class TaskInputModel
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