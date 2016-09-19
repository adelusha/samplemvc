using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
    {
    public class AssetManagerSoftwareRepository:IAssetManagerSoftwareRepository
        {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public AssetManagerSoftwareRepository(ServiceDeskContext context, ILogger logger)
            {
            _context = context;
            _logger = logger;
            }

        public List<AssetManager_Software> GetAllSoftwareAssets()
            {
            List<AssetManager_Software> allSoftwareAssets = _context.AssetManager_Software.ToList();
            return allSoftwareAssets;
            }

        public AssetManager_Software GetSoftwareAssetByID(int id)
            {
            AssetManager_Software software = _context.AssetManager_Software.FirstOrDefault(x => x.SoftwareAssetNumber == id);
            return software;
            }

        public bool DeleteSoftwareAsset(int id)
            {
            bool result = false;
            try
                {
                var assetToDelete = _context.AssetManager_Software.FirstOrDefault(s => s.SoftwareAssetNumber == id);
                _context.AssetManager_Software.Remove(assetToDelete);
                _context.SaveChanges();
                result = true;
                _logger.Info("Software Asset with assset number " + id + " was deleted.");

                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }
            return result;
            }

        public int CreateSoftwareAsset(AssetManager_Software softwareAsset)
            {
            softwareAsset.SoftwareAssetNumber = GetNextSoftwareAssetNumber();
            _context.AssetManager_Software.Add(softwareAsset);
            _context.SaveChanges();
            return softwareAsset.Id;
            }

        public int EditSoftwareAsset(int id, AssetManager_Software softwareAsset)
            {
            try
                {
                var oldSoftwareAsset = GetSoftwareAssetByID(id);
                if(oldSoftwareAsset != null)
                    {
                    oldSoftwareAsset.AccountingReqNumber = softwareAsset.AccountingReqNumber;
                    oldSoftwareAsset.AssociatedCompanyId = softwareAsset.AssociatedCompanyId;
                    oldSoftwareAsset.DateOfPurchase = softwareAsset.DateOfPurchase;
                    oldSoftwareAsset.EndOfSupportDate = softwareAsset.EndOfSupportDate;
                    oldSoftwareAsset.LicenseCount = softwareAsset.LicenseCount;
                    oldSoftwareAsset.LicensingInfo = softwareAsset.LicensingInfo;
                    oldSoftwareAsset.ModifiedById = softwareAsset.ModifiedById;
                    oldSoftwareAsset.ModifiedDate = softwareAsset.ModifiedDate;
                    oldSoftwareAsset.Name = softwareAsset.Name;
                    oldSoftwareAsset.Notes = softwareAsset.Notes;
                    oldSoftwareAsset.ProductOwnerId = softwareAsset.ProductOwnerId;
                    oldSoftwareAsset.ProductUsersId = softwareAsset.ProductUsersId;
                    oldSoftwareAsset.PublisherId = softwareAsset.PublisherId;
                    oldSoftwareAsset.SoftwareTypeId = softwareAsset.SoftwareTypeId;
                    oldSoftwareAsset.SupportingCompanyId = softwareAsset.SupportingCompanyId;
                    }
                _context.SaveChanges();
                _logger.Info("Software Asset with asset number" + id + " was updated.");
                return softwareAsset.Id;
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                return 0;
                }
            }


        private int GetNextSoftwareAssetNumber()
            {
            var asset = _context.AssetManager_Software.OrderByDescending(t => t.SoftwareAssetNumber).FirstOrDefault();

            if(asset != null)
                {
                return asset.SoftwareAssetNumber + 1;
                }
            else
                {
                return 1;
                }
            }
        }
    }
