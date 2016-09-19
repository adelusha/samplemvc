using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class AssetManager_Companies
    {
        public AssetManager_Companies()
        {
            this.AssetManager_AssetAttachments = new List<AssetManager_AssetAttachments>();
            this.AssetManager_Hardware = new List<AssetManager_Hardware>();
            this.AssetManager_Hardware1 = new List<AssetManager_Hardware>();
            this.AssetManager_Models = new List<AssetManager_Models>();
            this.AssetManager_Software = new List<AssetManager_Software>();
            this.AssetManager_Software1 = new List<AssetManager_Software>();
            this.HelpDesk_Tickets = new List<HelpDesk_Tickets>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public virtual ICollection<AssetManager_AssetAttachments> AssetManager_AssetAttachments { get; set; }
        public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware { get; set; }
        public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware1 { get; set; }
        public virtual ICollection<AssetManager_Models> AssetManager_Models { get; set; }
        public virtual ICollection<AssetManager_Software> AssetManager_Software { get; set; }
        public virtual ICollection<AssetManager_Software> AssetManager_Software1 { get; set; }
        public virtual ICollection<HelpDesk_Tickets> HelpDesk_Tickets { get; set; }
    }
}
