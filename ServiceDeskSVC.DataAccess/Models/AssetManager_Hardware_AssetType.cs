using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class AssetManager_Hardware_AssetType
    {
        public AssetManager_Hardware_AssetType()
        {
            this.AssetManager_Hardware = new List<AssetManager_Hardware>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionNotes { get; set; }
        public Nullable<int> EndOfLifeMo { get; set; }
        public int CategoryCode { get; set; }
        public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware { get; set; }
    }
}
