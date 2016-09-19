using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
    {
        public class AssetManagerHardwareTypeRepository:IAssetManagerHardwareAssetTypeRepository
        {
            private readonly ServiceDeskContext _context;
            private readonly ILogger _logger;

            public AssetManagerHardwareTypeRepository(ServiceDeskContext context, ILogger logger)
            {
                _context = context;
                _logger = logger;
            }

            public List<AssetManager_Hardware_AssetType> GetAllHardwareAssetTypes()
            {
                List<AssetManager_Hardware_AssetType> allHardwareTypes = _context.AssetManager_Hardware_AssetType.ToList();
                return allHardwareTypes;
            }

            public bool DeleteHardwareAssetTypes(int id)
            {
                bool result = false;
                try
                {
                    AssetManager_Hardware_AssetType HardwareType =
                        _context.AssetManager_Hardware_AssetType.FirstOrDefault(x => x.Id == id);
                    _context.AssetManager_Hardware_AssetType.Remove(HardwareType);
                    _context.SaveChanges();
                    result = true;
                    _logger.Info("The Hardware asset type with id " + id + " was deleted.");
                }
                catch(Exception ex)
                {
                    _logger.Error(ex);
                }

                return result;
            }

            public int CreateHardwareAssetTypes(AssetManager_Hardware_AssetType hardwareType)
            {
            //TODO: CHANGE WHEN BUILD CATEGORY TABLE
            hardwareType.CategoryCode = 0;
            _context.AssetManager_Hardware_AssetType.Add(hardwareType);
                _context.SaveChanges();
                return hardwareType.Id;
            }

            public int EditHardwareAssetTypes(int id, AssetManager_Hardware_AssetType hardwareType)
            {
                AssetManager_Hardware_AssetType oldHardwareType =
                    _context.AssetManager_Hardware_AssetType.FirstOrDefault(x => x.Id == id);
                try
                {
                if(oldHardwareType != null)
                {
                    oldHardwareType.CategoryCode = hardwareType.CategoryCode;
                    oldHardwareType.DescriptionNotes = hardwareType.DescriptionNotes;
                    oldHardwareType.EndOfLifeMo = hardwareType.EndOfLifeMo;
                    oldHardwareType.Name = hardwareType.Name;

                }
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {
                    _logger.Error(ex);
                }

                return hardwareType.Id;
            }

        }
    }
