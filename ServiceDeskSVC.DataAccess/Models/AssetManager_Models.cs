using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class AssetManager_Models
    {
        public AssetManager_Models()
        {
            this.AssetManager_AssetAttachments = new List<AssetManager_AssetAttachments>();
            this.AssetManager_Hardware = new List<AssetManager_Hardware>();
        }

        public int Id { get; set; }
        public string ModelName { get; set; }
        public int CompanyId { get; set; }
        public string DescriptionNotes { get; set; }
        public string SupportWebsite { get; set; }
        public string ManufacturerWebsite { get; set; }
        public virtual ICollection<AssetManager_AssetAttachments> AssetManager_AssetAttachments { get; set; }
        public virtual AssetManager_Companies AssetManager_Companies { get; set; }
        public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware { get; set; }
    }
}
