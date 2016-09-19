using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class AssetManager_Software
    {
        public AssetManager_Software()
        {
            this.AssetManager_AssetAttachments = new List<AssetManager_AssetAttachments>();
        }

        public int Id { get; set; }
        public int SoftwareAssetNumber { get; set; }
        public string Name { get; set; }
        public int SoftwareTypeId { get; set; }
        public Nullable<int> ProductOwnerId { get; set; }
        public Nullable<int> ProductUsersId { get; set; }
        public Nullable<int> SupportingCompanyId { get; set; }
        public Nullable<int> AssociatedCompanyId { get; set; }
        public int PublisherId { get; set; }
        public string AccountingReqNumber { get; set; }
        public string Notes { get; set; }
        public string LicensingInfo { get; set; }
        public System.DateTime DateOfPurchase { get; set; }
        public Nullable<System.DateTime> EndOfSupportDate { get; set; }
        public Nullable<int> LicenseCount { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedById { get; set; }
        public virtual ICollection<AssetManager_AssetAttachments> AssetManager_AssetAttachments { get; set; }
        public virtual AssetManager_Companies AssetManager_Companies { get; set; }
        public virtual AssetManager_Companies AssetManager_Companies1 { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users1 { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users2 { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users3 { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users4 { get; set; }
        public virtual AssetManager_Software_AssetType AssetManager_Software_AssetType { get; set; }
    }
}
