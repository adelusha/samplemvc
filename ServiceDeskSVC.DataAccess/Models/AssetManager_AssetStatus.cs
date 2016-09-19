using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class AssetManager_AssetStatus
    {
        public AssetManager_AssetStatus()
        {
            this.AssetManager_Hardware = new List<AssetManager_Hardware>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedById { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users1 { get; set; }
        public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware { get; set; }
    }
}
