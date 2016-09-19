using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager
    {
    public class AssetManager_Software_View_vm
        {
        [Required]
        public int SoftwareAssetNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SoftwareType { get; set; }

        public string ProductOwner { get; set; }

        public string ProductUsers { get; set; }

        public string SupportingCompany { get; set; }

        public string AssociatedCompany { get; set; }

        [Required]
        public string Publisher { get; set; }

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
        public string CreatedBy { get; set; }

        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public string  ModifiedBy { get; set; }
        }
    }
