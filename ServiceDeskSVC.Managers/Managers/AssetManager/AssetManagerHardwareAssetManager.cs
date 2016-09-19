using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using ILogging;
using ServiceDeskSVC.DataAccess.AssetManager;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;
using ServiceDeskSVC.Domain.Utilities;
using ServiceDeskSVC.Managers.AssetManager;

namespace ServiceDeskSVC.Managers.Managers.AssetManager
{
    public class AssetManagerHardwareAssetManager : IAssetManagerHardwareAssetManager
    {
        private readonly IAssetManagerHardwareAssetRepository _assetManagerHardwareAssetRepository;
        private readonly ILogger _logger;
        public AssetManagerHardwareAssetManager(IAssetManagerHardwareAssetRepository assetManagerHardwareAssetRepository, ILogger logger)
        {
            _assetManagerHardwareAssetRepository = assetManagerHardwareAssetRepository;
            _logger = logger;
        }

        private AssetManager_HardwareAsset_View_vm mapEntityToViewModel(AssetManager_Hardware EFModel)
        {
            _logger.Debug("Mapping Entity to Hardware Asset View Model");
            var vmH = new AssetManager_HardwareAsset_View_vm
            {
                HardwareAssetNumber = EFModel.HardwareAssetNumber,
                Name = EFModel.Name,
                AssetTag = EFModel.AssetTag,
                Type = EFModel.AssetManager_Hardware_AssetType.Name,
                Model = EFModel.AssetManager_Models.ModelName,
                Location = EFModel.NSLocation.LocationCity,
                SerialNumber = EFModel.SerialNumber,
                Status = EFModel.AssetManager_AssetStatus.Name,
                DisposalDate = EFModel.DisposalDate,
                Department = EFModel.Department.DepartmentName,
                AssignedTo = EFModel.ServiceDesk_Users.UserName,
                PurchaseOrderNumber = EFModel.PurchaseOrderNumber,
                Notes = EFModel.Notes,
                PurchasedFrom = EFModel.AssetManager_Companies.Name,
                SupportedBy = EFModel.AssetManager_Companies1.Name,
                DateOfPurchase = EFModel.DateOfPurchase,
                EndOfLifeDate = EFModel.EndOfLifeDate,
                DisposalMethod = GetEnumDescription((AssetManager_DisposalMethodEnum)Convert.ToInt32(EFModel.DisposalMethodCode)),
                ReassignedDate = EFModel.ReassignedDate,
                OldLocation = EFModel.NSLocation1.LocationCity,
                OldAssignedTo = EFModel.ServiceDesk_Users3.UserName,
                DeskRoomNumber = EFModel.DeskRoomNumber,
                IPAddress = EFModel.IPAddress,
                ComputerName = EFModel.ComputerName,
                CreatedBy = EFModel.ServiceDesk_Users1.UserName,
                CreatedDate = EFModel.CreatedDate,
                ModifiedDate = EFModel.ModifiedDate,
                ModifiedBy = EFModel.ServiceDesk_Users2 != null? EFModel.ServiceDesk_Users2.UserName: ""
            };

            return vmH;
        }

        private AssetManager_Hardware mapVMToEntityModel(AssetManager_HardwareAsset_vm VModel)
        {
            _logger.Debug("Mapping View Model to Hardware Asset Entity");
            var entModel = new AssetManager_Hardware
            {
                Name = VModel.Name,
                AssetTag = VModel.AssetTag,
                TypeId = VModel.TypeId,
                ModelId = VModel.ModelId,
                LocationId = VModel.LocationId,
                SerialNumber = VModel.SerialNumber,
                StatusId = VModel.StatusId,
                DisposalDate = VModel.DisposalDate,
                DepartmentId = VModel.DepartmentId,
                AssignedToId = VModel.AssignedToId,
                PurchaseOrderNumber = VModel.PurchaseOrderNumber,
                Notes = VModel.Notes,
                PurchasedFromId = VModel.PurchasedFromId,
                SupportedById = VModel.SupportedById,
                DateOfPurchase = VModel.DateOfPurchase,
                EndOfLifeDate = VModel.EndOfLifeDate,
                DisposalMethodCode = VModel.DisposalMethodCode,
                ReassignedDate = VModel.ReassignedDate,
                OldLocationId = VModel.OldLocationId,
                OldAssignedToId = VModel.OldAssignedToId,
                DeskRoomNumber = VModel.DeskRoomNumber,
                IPAddress = VModel.IPAddress,
                ComputerName = VModel.ComputerName,
            };
            return entModel;
        }
        private string GetEnumDescription(AssetManager_DisposalMethodEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public List<AssetManager_HardwareAsset_View_vm> GetAllHardwareAssets()
        {
            var allHardwareAssets = _assetManagerHardwareAssetRepository.GetAllHardwareAssets();
            if (allHardwareAssets == null)
            {
               _logger.Info("There are no Hardware Assets");
            }
            return allHardwareAssets.Select(mapEntityToViewModel).ToList();
        }

        public AssetManager_HardwareAsset_View_vm GetHardwareAssetById(int hardwareAssetNumber)
        {
            if (hardwareAssetNumber == 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be 0");
            }
            var hardwareAssetById = _assetManagerHardwareAssetRepository.GetHardwareAssetById(hardwareAssetNumber);
            return mapEntityToViewModel(hardwareAssetById);
        }

        public bool DeleteHardwareAssetById(int hardwareAssetNumber)
        {
            if (hardwareAssetNumber == 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be 0");
            }
            return _assetManagerHardwareAssetRepository.DeleteHardwareAssetById(hardwareAssetNumber);
        }

        public int CreateHardwareAsset(AssetManager_HardwareAsset_vm model, string userName)
        {
            var entityHardwareAsset = mapVMToEntityModel(model);
            //TODO: TEMPORARY UNTIL USERS TABLE IS IMPLEMENTED
            entityHardwareAsset.CreatedById = 2;
            entityHardwareAsset.CreatedDate = DateTime.Now;
            return _assetManagerHardwareAssetRepository.CreateHardwareAsset(entityHardwareAsset);
        }

        public int EditHardwareAssetById(int hardwareAssetNumber, AssetManager_HardwareAsset_vm model, string userName)
        {
            if (hardwareAssetNumber == 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be 0");
            }
            var entityHardwareAsset = mapVMToEntityModel(model);
            //TODO: TEMPORARY UNTIL USERS TABLE IS IMPLEMENTED
            entityHardwareAsset.ModifiedById = 2;
            entityHardwareAsset.ModifiedDate = DateTime.Now;
            return _assetManagerHardwareAssetRepository.EditHardwareAssetById(hardwareAssetNumber, entityHardwareAsset);
        }
    }
}
