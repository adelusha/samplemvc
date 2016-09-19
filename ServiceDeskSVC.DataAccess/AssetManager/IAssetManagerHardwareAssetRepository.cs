using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.AssetManager
{
    public interface IAssetManagerHardwareAssetRepository
    {
        List<AssetManager_Hardware> GetAllHardwareAssets();

        AssetManager_Hardware GetHardwareAssetById(int id);

        bool DeleteHardwareAssetById(int id);

        int CreateHardwareAsset(AssetManager_Hardware hardwareAsset);

        int EditHardwareAssetById(int id, AssetManager_Hardware hardwareAsset);
    }
}
