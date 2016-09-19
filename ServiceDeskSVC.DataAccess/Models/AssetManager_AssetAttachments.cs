using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class AssetManager_AssetAttachments
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public System.DateTime Date { get; set; }
        public byte[] Data { get; set; }
        public int FileSize { get; set; }
        public Nullable<int> HardwareAssetId { get; set; }
        public Nullable<int> SoftwareAssetId { get; set; }
        public Nullable<int> ModelId { get; set; }
        public Nullable<int> CompaniesId { get; set; }
        public string DescriptionNotes { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public int ModifiedById { get; set; }
        public virtual AssetManager_Companies AssetManager_Companies { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users { get; set; }
        public virtual AssetManager_Hardware AssetManager_Hardware { get; set; }
        public virtual AssetManager_Models AssetManager_Models { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users1 { get; set; }
        public virtual AssetManager_Software AssetManager_Software { get; set; }
    }
}
