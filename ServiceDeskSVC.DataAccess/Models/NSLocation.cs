using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class NSLocation
    {
        public NSLocation()
        {
            this.AssetManager_Hardware = new List<AssetManager_Hardware>();
            this.AssetManager_Hardware1 = new List<AssetManager_Hardware>();
            this.HelpDesk_Tickets = new List<HelpDesk_Tickets>();
            this.ServiceDesk_Users = new List<ServiceDesk_Users>();
        }

        public int Id { get; set; }
        public string LocationCity { get; set; }
        public string LocationState { get; set; }
        public int LocationZip { get; set; }
        public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware { get; set; }
        public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware1 { get; set; }
        public virtual ICollection<HelpDesk_Tickets> HelpDesk_Tickets { get; set; }
        public virtual ICollection<ServiceDesk_Users> ServiceDesk_Users { get; set; }
    }
}
