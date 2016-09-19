using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
    {
        public class AssetManagerSoftwareTypeRepository:IAssetManagerSoftwareAssetTypeRepository
        {
            private readonly ServiceDeskContext _context;
            private readonly ILogger _logger;

            public AssetManagerSoftwareTypeRepository(ServiceDeskContext context, ILogger logger)
            {
                _context = context;
                _logger = logger;
            }

            public List<AssetManager_Software_AssetType> GetAllSoftwareAssetTypes()
            {
                List<AssetManager_Software_AssetType> allSoftwareTypes = _context.AssetManager_Software_AssetType.ToList();
                return allSoftwareTypes;
            }

            public AssetManager_Software_AssetType GetSoftwareAssetTypeByID(int id)
                {
                AssetManager_Software_AssetType softwareType = _context.AssetManager_Software_AssetType.FirstOrDefault(x => x.Id == id);
                return softwareType;
                }

            public bool DeleteSoftwareAssetTypes(int id)
            {
                bool result = false;
                try
                {
                    AssetManager_Software_AssetType softwareType =
                        _context.AssetManager_Software_AssetType.FirstOrDefault(x => x.Id == id);
                    _context.AssetManager_Software_AssetType.Remove(softwareType);
                    _context.SaveChanges();
                    result = true;
                    _logger.Info("The Software asset type with id " + id + " was deleted.");
                }
                catch(Exception ex)
                {
                    _logger.Error(ex);
                }

                return result;
            }

            public int CreateSoftwareAssetTypes(AssetManager_Software_AssetType softwareType)
            {
                //TODO: CHANGE WHEN BUILD CATEGORY TABLE
                softwareType.CategoryCode = 0;
            _context.AssetManager_Software_AssetType.Add(softwareType);
                _context.SaveChanges();
                return softwareType.Id;
            }

            public int EditSoftwareAssetTypes(int id, AssetManager_Software_AssetType softwareType)
            {
                AssetManager_Software_AssetType oldSoftwareType =
                    _context.AssetManager_Software_AssetType.FirstOrDefault(x => x.Id == id);
                try
                {
                if(oldSoftwareType != null)
                {
                    oldSoftwareType.CategoryCode = softwareType.CategoryCode;
                    oldSoftwareType.DescriptionNotes = softwareType.DescriptionNotes;
                    oldSoftwareType.EndOfLifeMo = softwareType.EndOfLifeMo;
                    oldSoftwareType.Name = softwareType.Name;
                }
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {
                    _logger.Error(ex);
                }

                return softwareType.Id;
            }

        }
    }
