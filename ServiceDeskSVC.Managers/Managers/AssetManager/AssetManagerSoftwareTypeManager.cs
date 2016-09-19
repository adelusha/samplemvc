using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class AssetManagerSoftwareTypeManager:IAssetManagerSoftwareTypeManager
        {
        private readonly IAssetManagerSoftwareAssetTypeRepository _assetManagerSoftwareTypeRepository;
        private readonly ILogger _logger;

        public AssetManagerSoftwareTypeManager(
            IAssetManagerSoftwareAssetTypeRepository assetManagerSoftwareTypeRepository, ILogger logger)
            {
            _assetManagerSoftwareTypeRepository = assetManagerSoftwareTypeRepository;
            _logger = logger;
            }

        private AssetManager_SoftwareType_vm mapEntityToViewSoftwareType(
            AssetManager_Software_AssetType EFSoftwareType)
            {
            _logger.Debug("Mapping Entity to Software Asset Type View Model.");
            var vmST = new AssetManager_SoftwareType_vm
            {
                Id = EFSoftwareType.Id,
                Name = EFSoftwareType.Name,
                EndOfLifeMo = EFSoftwareType.EndOfLifeMo,
                CategoryCode = EFSoftwareType.CategoryCode,
                DescriptionNotes = EFSoftwareType.DescriptionNotes
            };

            return vmST;
            }

        private AssetManager_Software_AssetType mapViewModelToEntitySoftwareType(
            AssetManager_SoftwareType_vm VMSoftwareType)
            {
            var models = new AssetManager_Software_AssetType
            {
                Id = VMSoftwareType.Id,
                Name = VMSoftwareType.Name,
                EndOfLifeMo = VMSoftwareType.EndOfLifeMo,
                CategoryCode = VMSoftwareType.CategoryCode,
                DescriptionNotes = VMSoftwareType.DescriptionNotes
            };

            return models;
            }

        public List<AssetManager_SoftwareType_vm> GetAllSoftwareTypes()
            {
            var allSoftwareTypes = _assetManagerSoftwareTypeRepository.GetAllSoftwareAssetTypes();
            return allSoftwareTypes.Select(mapEntityToViewSoftwareType).ToList();
            }
        public AssetManager_SoftwareType_vm GetSoftwareAssetTypeByID(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0");
                }
            var softwareAssetTypeById = _assetManagerSoftwareTypeRepository.GetSoftwareAssetTypeByID(id);
            return mapEntityToViewSoftwareType(softwareAssetTypeById);
            }

        public bool DeleteSoftwareTypeById(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _assetManagerSoftwareTypeRepository.DeleteSoftwareAssetTypes(id);
            }

        public int CreateSoftwareType(AssetManager_SoftwareType_vm softwareType)
            {
            return _assetManagerSoftwareTypeRepository.CreateSoftwareAssetTypes(mapViewModelToEntitySoftwareType(softwareType));
            }

        public int EditSoftwareTypeById(int id, AssetManager_SoftwareType_vm softwareType)
            {
            return _assetManagerSoftwareTypeRepository.EditSoftwareAssetTypes(id, mapViewModelToEntitySoftwareType(softwareType));
            }
        }

    }
