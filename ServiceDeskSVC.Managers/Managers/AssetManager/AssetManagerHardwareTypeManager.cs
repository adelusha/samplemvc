using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class AssetManagerHardwareTypeManager:IAssetManagerHardwareTypeManager
        {
        private readonly IAssetManagerHardwareAssetTypeRepository _assetManagerHardwareTypeRepository;
        private readonly ILogger _logger;

        public AssetManagerHardwareTypeManager(
            IAssetManagerHardwareAssetTypeRepository assetManagerHardwareTypeRepository, ILogger logger)
            {
            _assetManagerHardwareTypeRepository = assetManagerHardwareTypeRepository;
            _logger = logger;
            }

        private AssetManager_HardwareType_vm mapEntityToViewHardwareType(
            AssetManager_Hardware_AssetType EFHardwareType)
            {
            _logger.Debug("Mapping Entity to Hardware Asset Type View Model.");
            var vmST = new AssetManager_HardwareType_vm
            {
                Id = EFHardwareType.Id,
                Name = EFHardwareType.Name,
                EndOfLifeMo = EFHardwareType.EndOfLifeMo,
                CategoryCode = EFHardwareType.CategoryCode,
                DescriptionNotes = EFHardwareType.DescriptionNotes
            };

            return vmST;
            }

        private AssetManager_Hardware_AssetType mapViewModelToEntityHardwareType(
            AssetManager_HardwareType_vm VMHardwareType)
            {
            var models = new AssetManager_Hardware_AssetType
            {
                Id = VMHardwareType.Id,
                Name = VMHardwareType.Name,
                EndOfLifeMo = VMHardwareType.EndOfLifeMo,
                CategoryCode = VMHardwareType.CategoryCode,
                DescriptionNotes = VMHardwareType.DescriptionNotes
            };

            return models;
            }

        public List<AssetManager_HardwareType_vm> GetAllHardwareTypes()
            {
            var allHardwareTypes = _assetManagerHardwareTypeRepository.GetAllHardwareAssetTypes();
            return allHardwareTypes.Select(mapEntityToViewHardwareType).ToList();
            }

        public bool DeleteHardwareTypeById(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _assetManagerHardwareTypeRepository.DeleteHardwareAssetTypes(id);
            }

        public int CreateHardwareType(AssetManager_HardwareType_vm HardwareType)
            {
            return _assetManagerHardwareTypeRepository.CreateHardwareAssetTypes(mapViewModelToEntityHardwareType(HardwareType));
            }

        public int EditHardwareTypeById(int id, AssetManager_HardwareType_vm HardwareType)
            {
            return _assetManagerHardwareTypeRepository.EditHardwareAssetTypes(id, mapViewModelToEntityHardwareType(HardwareType));
            }
        }

    }
