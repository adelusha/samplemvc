using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.AssetManager;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories.AssetManager
    {
    public class AssetManagerHardwareAssetRepository:IAssetManagerHardwareAssetRepository
        {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public AssetManagerHardwareAssetRepository(ServiceDeskContext context, ILogger logger)
            {
            _context = context;
            _logger = logger;
            }

        public List<AssetManager_Hardware> GetAllHardwareAssets()
            {
            List<AssetManager_Hardware> allHardwareAssets = _context.AssetManager_Hardware.ToList();
            return allHardwareAssets;
            }

        public AssetManager_Hardware GetHardwareAssetById(int HardwareAssetNumber)
            {
            AssetManager_Hardware hardwareAsset = _context.AssetManager_Hardware.FirstOrDefault(x => x.HardwareAssetNumber == HardwareAssetNumber);
            return hardwareAsset;
            }

        public int CreateHardwareAsset(AssetManager_Hardware hardwareAsset)
            {
            try
                {
                hardwareAsset.HardwareAssetNumber = GetNextHardwareAssetNumber();
                _context.AssetManager_Hardware.Add(hardwareAsset);
                _context.SaveChanges();
                }
            catch(DbEntityValidationException ex)
                {

                }
            return hardwareAsset.HardwareAssetNumber;
            }

        private int GetNextHardwareAssetNumber()
            {
            var asset = _context.AssetManager_Hardware.OrderByDescending(t => t.HardwareAssetNumber).FirstOrDefault();

            if(asset != null)
                {
                return asset.HardwareAssetNumber + 1;
                }
            else
                {
                return 1;
                }
            }

        public int EditHardwareAssetById(int HardwareAssetNumber, AssetManager_Hardware hardwareAsset)
            {
            AssetManager_Hardware oldHardware = GetHardwareAssetById(HardwareAssetNumber);

            try
                {
                oldHardware.Name = hardwareAsset.Name;
                oldHardware.AssetTag = hardwareAsset.AssetTag;
                oldHardware.TypeId = hardwareAsset.TypeId;
                oldHardware.ModelId = hardwareAsset.ModelId;
                oldHardware.LocationId = hardwareAsset.LocationId;
                oldHardware.SerialNumber = hardwareAsset.SerialNumber;
                oldHardware.StatusId = hardwareAsset.StatusId;
                oldHardware.DisposalDate = hardwareAsset.DisposalDate;
                oldHardware.DepartmentId = hardwareAsset.DepartmentId;
                oldHardware.AssignedToId = hardwareAsset.AssignedToId;
                oldHardware.PurchaseOrderNumber = hardwareAsset.PurchaseOrderNumber;
                oldHardware.Notes = hardwareAsset.Notes;
                oldHardware.PurchasedFromId = hardwareAsset.PurchasedFromId;
                oldHardware.SupportedById = hardwareAsset.SupportedById;
                oldHardware.DateOfPurchase = hardwareAsset.DateOfPurchase;
                oldHardware.EndOfLifeDate = hardwareAsset.EndOfLifeDate;
                oldHardware.DisposalMethodCode = hardwareAsset.DisposalMethodCode;
                oldHardware.ReassignedDate = hardwareAsset.ReassignedDate;
                oldHardware.OldLocationId = hardwareAsset.OldLocationId;
                oldHardware.OldAssignedToId = hardwareAsset.OldAssignedToId;
                oldHardware.DeskRoomNumber = hardwareAsset.DeskRoomNumber;
                oldHardware.IPAddress = hardwareAsset.IPAddress;
                oldHardware.ComputerName = hardwareAsset.ComputerName;
                oldHardware.ModifiedDate = hardwareAsset.ModifiedDate;
                oldHardware.ModifiedById = hardwareAsset.ModifiedById;

                _context.SaveChanges();
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return oldHardware.HardwareAssetNumber;
            }


        public bool DeleteHardwareAssetById(int HardwareAssetNumber)
            {
            bool result = false;
            try
                {
                AssetManager_Hardware hardware = GetHardwareAssetById(HardwareAssetNumber);
                _context.AssetManager_Hardware.Remove(hardware);
                _context.SaveChanges();
                result = true;
                _logger.Info("Model with Hardware Asset Number " + HardwareAssetNumber + " was deleted.");

                }
            catch(Exception Ex)
                {
                _logger.Error(Ex);
                }

            return result;
            }

        }
    }
