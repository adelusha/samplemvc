using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.AssetManager;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;

namespace ServiceDeskSVC.Managers.Managers.AssetManager
    {
    public class AssetManagerModelsManager:IAssetManagerModelsManager
        {
        private readonly IAssetManagerModelsRepository _assetManagerModelsRepository;
        private readonly ILogger _logger;
        public AssetManagerModelsManager(IAssetManagerModelsRepository assetManagerModelsRepository, ILogger logger)
        {
            _assetManagerModelsRepository = assetManagerModelsRepository;
            _logger = logger;
            }

        private AssetManager_Models_vm mapEntityToViewModel(AssetManager_Models EFModel)
            {
            _logger.Debug("Mapping Entity to Model View Model.");
            var vmM = new AssetManager_Models_vm
                {
                    Id = EFModel.Id,
                    ModelName = EFModel.ModelName,
                    CompanyId = EFModel.CompanyId,
                    CompanyName = EFModel.AssetManager_Companies != null ? EFModel.AssetManager_Companies.Name : "",
                    DescriptionNotes = EFModel.DescriptionNotes,
                    ManufacturerWebsite = EFModel.ManufacturerWebsite,
                    SupportWebsite = EFModel.SupportWebsite,
                    AssetManager_Companies = new AssetManager_Models_Company
                    {
                        CompanyId = EFModel.CompanyId,
                        CompanyName = EFModel.AssetManager_Companies != null ? EFModel.AssetManager_Companies.Name : ""
                    }
                };

            return vmM;
            }

        private AssetManager_Models mapViewModelToEntityModel(AssetManager_Models_vm VMModel)
            {
            var models = new AssetManager_Models
                {
                    Id = VMModel.Id,
                    ModelName = VMModel.ModelName,
                    CompanyId = VMModel.CompanyId,
                    DescriptionNotes = VMModel.DescriptionNotes,
                    ManufacturerWebsite = VMModel.ManufacturerWebsite,
                    SupportWebsite = VMModel.SupportWebsite
                };

            return models;
            }

        public List<AssetManager_Models_vm> GetAllModels()
            {
            var allModels = _assetManagerModelsRepository.GetAllModels();
            return allModels.Select(mapEntityToViewModel).ToList();
            }

        public bool DeleteModelById(int id)
            {
            if(id < 1)
                {
                throw new ArgumentOutOfRangeException("Id cannot be less than 1.");
                }

            return _assetManagerModelsRepository.DeleteModels(id);
            }

        public int CreateModel(AssetManager_Models_vm model)
            {
            return _assetManagerModelsRepository.CreateModel(mapViewModelToEntityModel(model));
            }

        public int EditModelById(int id, AssetManager_Models_vm model)
            {
            return _assetManagerModelsRepository.EditModel(id, mapViewModelToEntityModel(model));
            }
        }
    }
