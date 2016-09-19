using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager
{
    public class AssetManager_HardwareAsset_vm
    {
        //public int? HardwareAssetNumber { get; set; }
        public string Name { get; set; }
        public string AssetTag { get; set; }
        public int TypeId { get; set; }
        public int ModelId { get; set; }
        public int LocationId { get; set; }
        public string SerialNumber { get; set; }
        public int StatusId { get; set; }
        public DateTime? DisposalDate { get; set; }
        public int? DepartmentId { get; set; }
        public int? AssignedToId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string Notes { get; set; }
        public int PurchasedFromId { get; set; }
        public int? SupportedById { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime? EndOfLifeDate { get; set; }
        public int? DisposalMethodCode { get; set; }
        public DateTime? ReassignedDate { get; set; }
        public int? OldLocationId { get; set; }
        public int? OldAssignedToId { get; set; }
        public int? DeskRoomNumber { get; set; }
        public string IPAddress { get; set; }
        public string ComputerName { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public int? CreatedById { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public int? ModifiedById { get; set; }
        //public  ICollection<AssetManager_AssetAttachments> AssetManager_AssetAttachments { get; set; }
        //public  AssetManager_AssetStatus AssetManager_AssetStatus { get; set; }
        //public  AssetManager_Companies AssetManager_Companies { get; set; }
        //public  AssetManager_Companies AssetManager_Companies1 { get; set; }
        //public  AssetManager_Companies AssetManager_Companies2 { get; set; }
        //public  ServiceDesk_Users ServiceDesk_Users { get; set; }
        //public  AssetManager_Hardware_AssetType AssetManager_Hardware_AssetType { get; set; }
        //public  ServiceDesk_Users ServiceDesk_Users1 { get; set; }
        //public  Department Department { get; set; }
        //public  NSLocation NSLocation { get; set; }
        //public  AssetManager_Models AssetManager_Models { get; set; }
        //public  ServiceDesk_Users ServiceDesk_Users2 { get; set; }
        //public  NSLocation NSLocation1 { get; set; }
    }
}
