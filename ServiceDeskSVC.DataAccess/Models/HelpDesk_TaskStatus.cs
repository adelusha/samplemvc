using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class HelpDesk_TaskStatus
    {
        public HelpDesk_TaskStatus()
        {
            this.HelpDesk_Tasks = new List<HelpDesk_Tasks>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public virtual ICollection<HelpDesk_Tasks> HelpDesk_Tasks { get; set; }
    }
}
