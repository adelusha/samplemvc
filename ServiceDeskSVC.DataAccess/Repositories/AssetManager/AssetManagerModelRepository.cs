using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.AssetManager;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
    {
    public class AssetManagerModelRepository:IAssetManagerModelsRepository
        {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public AssetManagerModelRepository(ServiceDeskContext context, ILogger logger)
            {
            _context = context;
            _logger = logger;
            }

        public List<AssetManager_Models> GetAllModels()
            {
            List<AssetManager_Models> allModels = _context.AssetManager_Models.ToList();
            return allModels;
            }

        public bool DeleteModels(int id)
            {
            bool result = false;
            try
                {
                AssetManager_Models model = _context.AssetManager_Models.FirstOrDefault(x => x.Id == id);
                _context.AssetManager_Models.Remove(model);
                _context.SaveChanges();
                result = true;
                _logger.Info("Model with id " + id + " was deleted.");
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return result;
            }

        public int CreateModel(AssetManager_Models model)
            {
            _context.AssetManager_Models.Add(model);
            _context.SaveChanges();
            return model.Id;
            }

        public int EditModel(int id, AssetManager_Models model)
            {
            AssetManager_Models oldModel = _context.AssetManager_Models.FirstOrDefault(x => x.Id == id);
            try
                {
                if(oldModel != null)
                    {
                    oldModel.CompanyId = model.CompanyId;
                    oldModel.DescriptionNotes = model.DescriptionNotes;
                    oldModel.ManufacturerWebsite = model.ManufacturerWebsite;
                    oldModel.ModelName = model.ModelName;
                   oldModel.SupportWebsite = model.SupportWebsite;
                    }
                _context.SaveChanges();
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return model.Id;
            }
        }
    }
