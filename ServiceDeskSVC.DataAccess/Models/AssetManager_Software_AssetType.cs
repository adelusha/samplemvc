using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class AssetManager_Software_AssetType
    {
        public AssetManager_Software_AssetType()
        {
            this.AssetManager_Software = new List<AssetManager_Software>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionNotes { get; set; }
        public Nullable<int> EndOfLifeMo { get; set; }
        public int CategoryCode { get; set; }
        public virtual ICollection<AssetManager_Software> AssetManager_Software { get; set; }
    }
}
