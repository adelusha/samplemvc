using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class Department
    {
        public Department()
        {
            this.AssetManager_Hardware = new List<AssetManager_Hardware>();
            this.ServiceDesk_Users = new List<ServiceDesk_Users>();
            this.HelpDesk_Tickets = new List<HelpDesk_Tickets>();
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware { get; set; }
        public virtual ICollection<ServiceDesk_Users> ServiceDesk_Users { get; set; }
        public virtual ICollection<HelpDesk_Tickets> HelpDesk_Tickets { get; set; }
    }
}
