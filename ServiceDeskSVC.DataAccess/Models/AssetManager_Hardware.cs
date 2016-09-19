using System;
using System.Collections.Generic;

namespace ServiceDeskSVC.DataAccess.Models
{
    public partial class AssetManager_Hardware
    {
        public AssetManager_Hardware()
        {
            this.AssetManager_AssetAttachments = new List<AssetManager_AssetAttachments>();
        }

        public int Id { get; set; }
        public int HardwareAssetNumber { get; set; }
        public string Name { get; set; }
        public string AssetTag { get; set; }
        public int TypeId { get; set; }
        public int ModelId { get; set; }
        public int LocationId { get; set; }
        public string SerialNumber { get; set; }
        public int StatusId { get; set; }
        public Nullable<System.DateTime> DisposalDate { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> AssignedToId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string Notes { get; set; }
        public int PurchasedFromId { get; set; }
        public Nullable<int> SupportedById { get; set; }
        public System.DateTime DateOfPurchase { get; set; }
        public Nullable<System.DateTime> EndOfLifeDate { get; set; }
        public Nullable<int> DisposalMethodCode { get; set; }
        public Nullable<System.DateTime> ReassignedDate { get; set; }
        public Nullable<int> OldLocationId { get; set; }
        public Nullable<int> OldAssignedToId { get; set; }
        public Nullable<int> DeskRoomNumber { get; set; }
        public string IPAddress { get; set; }
        public string ComputerName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedById { get; set; }
        public virtual ICollection<AssetManager_AssetAttachments> AssetManager_AssetAttachments { get; set; }
        public virtual AssetManager_AssetStatus AssetManager_AssetStatus { get; set; }
        public virtual AssetManager_Companies AssetManager_Companies { get; set; }
        public virtual AssetManager_Companies AssetManager_Companies1 { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users1 { get; set; }
        public virtual Department Department { get; set; }
        public virtual NSLocation NSLocation { get; set; }
        public virtual AssetManager_Models AssetManager_Models { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users2 { get; set; }
        public virtual ServiceDesk_Users ServiceDesk_Users3 { get; set; }
        public virtual NSLocation NSLocation1 { get; set; }
        public virtual AssetManager_Hardware_AssetType AssetManager_Hardware_AssetType { get; set; }
    }
}
