using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class AssetManagerSoftwareManager:IAssetManagerSoftwareManager
        {
        private readonly IAssetManagerSoftwareRepository _assetManagerSoftwareRepository;
        private readonly INSUserRepository _nsUserRepository;
        private readonly ILogger _logger;

        public AssetManagerSoftwareManager(
            IAssetManagerSoftwareRepository assetManagerSoftwareRepository, INSUserRepository nsUserRepository, ILogger logger)
            {
            _assetManagerSoftwareRepository = assetManagerSoftwareRepository;
            _nsUserRepository = nsUserRepository;
            _logger = logger;
            }

        private AssetManager_Software_vm mapEntityToViewSoftware(
            AssetManager_Software EFSoftware)
            {
            _logger.Debug("Mapping Entity to Software Asset View Model.");
            var vmSA = new AssetManager_Software_vm
            {
                SoftwareAssetNumber = EFSoftware.SoftwareAssetNumber,
                Name = EFSoftware.Name,
                AccountingReqNumber = EFSoftware.AccountingReqNumber,
                DateOfPurchase = EFSoftware.DateOfPurchase,
                CreatedByUserName = EFSoftware.ServiceDesk_Users == null ? null : EFSoftware.ServiceDesk_Users.UserName,
                CreatedDate = EFSoftware.CreatedDate,
                AssociatedCompanyId = EFSoftware.AssociatedCompanyId,
                EndOfSupportDate = EFSoftware.EndOfSupportDate,
                LicenseCount = EFSoftware.LicenseCount,
                Notes = EFSoftware.Notes,
                ModifiedByUserName = EFSoftware.ServiceDesk_Users2 == null ? null : EFSoftware.ServiceDesk_Users2.UserName,
                ModifiedDate = EFSoftware.ModifiedDate,
                LicensingInfo = EFSoftware.LicensingInfo,
                ProductOwnerUserName = EFSoftware.ServiceDesk_Users3 == null ? null : EFSoftware.ServiceDesk_Users3.UserName,
                ProductUsersUserName = EFSoftware.ServiceDesk_Users4 == null ? null : EFSoftware.ServiceDesk_Users4.UserName,
                PublisherUserName = EFSoftware.ServiceDesk_Users1 == null ? null : EFSoftware.ServiceDesk_Users1.UserName,
                SoftwareTypeId = EFSoftware.SoftwareTypeId,
                SupportingCompanyId = EFSoftware.SupportingCompanyId,
                ProductOwner = EFSoftware.ServiceDesk_Users3 == null ? null : new Software_Users()
                {
                    SID = EFSoftware.ServiceDesk_Users3.SID,
                    UserName = EFSoftware.ServiceDesk_Users3.UserName,
                    DisplayName = EFSoftware.ServiceDesk_Users3.FirstName + " " + EFSoftware.ServiceDesk_Users3.LastName
                },
                ProductUser = EFSoftware.ServiceDesk_Users4 == null ? null : new Software_Users()
                {
                    SID = EFSoftware.ServiceDesk_Users4.SID,
                    UserName = EFSoftware.ServiceDesk_Users4.UserName,
                    DisplayName = EFSoftware.ServiceDesk_Users4.FirstName + " " + EFSoftware.ServiceDesk_Users4.LastName
                },

                Publisher = EFSoftware.ServiceDesk_Users1 == null ? null : new Software_Users()
                {
                    SID = EFSoftware.ServiceDesk_Users1.SID,
                    UserName = EFSoftware.ServiceDesk_Users1.UserName,
                    DisplayName = EFSoftware.ServiceDesk_Users1.FirstName + " " + EFSoftware.ServiceDesk_Users1.LastName
                },
                CreatedBy = EFSoftware.ServiceDesk_Users == null ? null : new Software_Users()
                {
                    SID = EFSoftware.ServiceDesk_Users.SID,
                    UserName = EFSoftware.ServiceDesk_Users.UserName,
                    DisplayName = EFSoftware.ServiceDesk_Users.FirstName + " " + EFSoftware.ServiceDesk_Users.LastName
                },
                ModifiedBy = EFSoftware.ServiceDesk_Users2 == null ? null : new Software_Users()
                {
                    SID = EFSoftware.ServiceDesk_Users2.SID,
                    UserName = EFSoftware.ServiceDesk_Users2.UserName,
                    DisplayName = EFSoftware.ServiceDesk_Users2.FirstName + " " + EFSoftware.ServiceDesk_Users2.LastName
                },
            };

            return vmSA;
            }

        //to remove
        private AssetManager_Software_View_vm mapEntityToViewSoftwareAsset(AssetManager_Software EFSoftware)
            {
            _logger.Debug("Mapping Entity to Software Asset View Model.");
            var vmSA = new AssetManager_Software_View_vm
            {
                SoftwareAssetNumber = EFSoftware.SoftwareAssetNumber,
                Name = EFSoftware.Name,
                AccountingReqNumber = EFSoftware.AccountingReqNumber,
                DateOfPurchase = EFSoftware.DateOfPurchase,
                ProductOwner = EFSoftware.ServiceDesk_Users3 == null ? "" : (EFSoftware.ServiceDesk_Users3.FirstName + " " + EFSoftware.ServiceDesk_Users3.LastName),
                ProductUsers = EFSoftware.ServiceDesk_Users4 == null ? "" : (EFSoftware.ServiceDesk_Users4.FirstName + " " + EFSoftware.ServiceDesk_Users4.LastName),
                Publisher = EFSoftware.ServiceDesk_Users1 == null ? "" : (EFSoftware.ServiceDesk_Users1.FirstName + " " + EFSoftware.ServiceDesk_Users1.LastName),
                CreatedBy = EFSoftware.ServiceDesk_Users == null ? "" : (EFSoftware.ServiceDesk_Users.FirstName + " " + EFSoftware.ServiceDesk_Users3.LastName),
                ModifiedBy = EFSoftware.ServiceDesk_Users2 == null ? "" : (EFSoftware.ServiceDesk_Users2.FirstName + " " + EFSoftware.ServiceDesk_Users2.LastName),
                CreatedDate = EFSoftware.CreatedDate,
                AssociatedCompany = EFSoftware.AssetManager_Companies == null ? "" : EFSoftware.AssetManager_Companies.Name,
                EndOfSupportDate = EFSoftware.EndOfSupportDate,
                LicenseCount = EFSoftware.LicenseCount,
                Notes = EFSoftware.Notes,
                ModifiedDate = EFSoftware.ModifiedDate,
                LicensingInfo = EFSoftware.LicensingInfo,
                SoftwareType = EFSoftware.AssetManager_Software_AssetType.Name,
                SupportingCompany = EFSoftware.AssetManager_Companies1 == null ? "" : EFSoftware.AssetManager_Companies1.Name
            };

            return vmSA;
            }

        private AssetManager_Software mapViewModelToEntitySoftware(
            AssetManager_Software_vm VMSoftware)
            {
            ServiceDesk_Users createdBy = _nsUserRepository.GetUserByUserName(VMSoftware.CreatedByUserName);
            ServiceDesk_Users modifiedBy = _nsUserRepository.GetUserByUserName(VMSoftware.ModifiedByUserName);
            ServiceDesk_Users productOwner = _nsUserRepository.GetUserByUserName(VMSoftware.ProductOwnerUserName);
            ServiceDesk_Users productUser = _nsUserRepository.GetUserByUserName(VMSoftware.ProductUsersUserName);
            ServiceDesk_Users publisher = _nsUserRepository.GetUserByUserName(VMSoftware.PublisherUserName);
            var softwareAsset = new AssetManager_Software
            {
                SoftwareAssetNumber = VMSoftware.SoftwareAssetNumber,
                Name = VMSoftware.Name,
                AccountingReqNumber = VMSoftware.AccountingReqNumber,
                DateOfPurchase = VMSoftware.DateOfPurchase,
                CreatedById = createdBy.Id,
                CreatedDate = VMSoftware.CreatedDate,
                AssociatedCompanyId = VMSoftware.AssociatedCompanyId,
                EndOfSupportDate = VMSoftware.EndOfSupportDate,
                LicenseCount = VMSoftware.LicenseCount,
                Notes = VMSoftware.Notes,
                ModifiedById = modifiedBy == null ? (int?)null : modifiedBy.Id,
                ModifiedDate = VMSoftware.ModifiedDate,
                LicensingInfo = VMSoftware.LicensingInfo,
                ProductOwnerId = productOwner == null ? (int?)null : productOwner.Id,
                ProductUsersId = productUser == null ? (int?)null : productUser.Id,
                PublisherId = publisher.Id,
                SoftwareTypeId = VMSoftware.SoftwareTypeId,
                SupportingCompanyId = VMSoftware.SupportingCompanyId
            };

            return softwareAsset;
            }


        public AssetManager_Software_vm GetSoftwareAssetByID(int softwareAssetNumber)
            {
            if(softwareAssetNumber == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0");
                }
            var softwareAssetById = _assetManagerSoftwareRepository.GetSoftwareAssetByID(softwareAssetNumber);
            return mapEntityToViewSoftware(softwareAssetById);
            }

        public List<AssetManager_Software_View_vm> GetAllSoftwareAssets()
            {
            var allSoftwares = _assetManagerSoftwareRepository.GetAllSoftwareAssets();
            return allSoftwares.Select(mapEntityToViewSoftwareAsset).ToList();
            }

        public bool DeleteSoftwareAssetById(int assetNumber)
            {
            if(assetNumber == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _assetManagerSoftwareRepository.DeleteSoftwareAsset(assetNumber);
            }

        public int CreateSoftwareAsset(AssetManager_Software_vm softwareAsset)
            {
            return _assetManagerSoftwareRepository.CreateSoftwareAsset(mapViewModelToEntitySoftware(softwareAsset));
            }

        public int EditSoftwareAssetById(int id, AssetManager_Software_vm softwareAsset)
            {
            return _assetManagerSoftwareRepository.EditSoftwareAsset(id, mapViewModelToEntitySoftware(softwareAsset));
            }
        }

    }
