using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
    {
    public interface IAssetManagerSoftwareRepository
    {
        List<AssetManager_Software> GetAllSoftwareAssets();

        AssetManager_Software GetSoftwareAssetByID(int id);

        bool DeleteSoftwareAsset(int id);

        int CreateSoftwareAsset(AssetManager_Software softwareAsset);

        int EditSoftwareAsset(int id, AssetManager_Software softwareAsset);
        }
    }
