using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager
{
    public class AssetManager_HardwareAsset_View_vm
    {
        public int HardwareAssetNumber { get; set; }
        public string Name { get; set; }
        public string AssetTag { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Location { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public DateTime? DisposalDate { get; set; }
        public string Department { get; set; }
        public string AssignedTo { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string Notes { get; set; }
        public string PurchasedFrom { get; set; }
        public string SupportedBy { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime? EndOfLifeDate { get; set; }
        public string DisposalMethod { get; set; }
        public DateTime? ReassignedDate { get; set; }
        public string OldLocation { get; set; }
        public string OldAssignedTo { get; set; }
        public int? DeskRoomNumber { get; set; }
        public string IPAddress { get; set; }
        public string ComputerName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
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
