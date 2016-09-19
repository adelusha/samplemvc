using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;

namespace ServiceDeskSVC.Managers
{
    public interface IAssetManagerSoftwareManager
        {
        List<AssetManager_Software_View_vm> GetAllSoftwareAssets();

        AssetManager_Software_vm GetSoftwareAssetByID(int id);

        bool DeleteSoftwareAssetById(int id);

        int CreateSoftwareAsset(AssetManager_Software_vm softwareAsset);

        int EditSoftwareAssetById(int id, AssetManager_Software_vm softwareAsset);

        }
}
