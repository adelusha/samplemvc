using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager
    {
    public class AssetManager_Software_vm
        {
        [Required]
        public int SoftwareAssetNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SoftwareTypeId { get; set; }

        public string ProductOwnerUserName { get; set; }

        public string ProductUsersUserName { get; set; }

        public Nullable<int> SupportingCompanyId { get; set; }

        public Nullable<int> AssociatedCompanyId { get; set; }

        [Required]
        public string PublisherUserName { get; set; }

        [Required]
        public string AccountingReqNumber { get; set; }

        public string Notes { get; set; }

        public string LicensingInfo { get; set; }

        [Required]
        public System.DateTime DateOfPurchase { get; set; }

        public Nullable<System.DateTime> EndOfSupportDate { get; set; }

        public Nullable<int> LicenseCount { get; set; }

        [Required]
        public System.DateTime CreatedDate { get; set; }

        [Required]
        public string CreatedByUserName{ get; set; }

        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public string ModifiedByUserName { get; set; }

        //public virtual ICollection<AssetManager_AssetAttachments> AssetManager_AssetAttachments { get; set; }
        //public virtual AssetManager_Companies AssetManager_Companies { get; set; }
        //public virtual AssetManager_Companies AssetManager_Companies1 { get; set; }
        //public virtual AssetManager_Companies AssetManager_Companies2 { get; set; }
        public virtual Software_Users ProductOwner { get; set; }
        public virtual Software_Users ProductUser { get; set; }
        public virtual Software_Users Publisher { get; set; }
        public virtual Software_Users CreatedBy { get; set; }
        public virtual Software_Users ModifiedBy { get; set; }
        //public virtual AssetManager_Software_AssetType AssetManager_Software_AssetType { get; set; }
        }

    public class Software_Users
        {
        public string SID { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }
        }
    }
