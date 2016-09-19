using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;

namespace ServiceDeskSVC.Managers.AssetManager
{
    public interface IAssetManagerHardwareAssetManager
    {
        List<AssetManager_HardwareAsset_View_vm> GetAllHardwareAssets();

        AssetManager_HardwareAsset_View_vm GetHardwareAssetById(int hardwareAssetNumber);

        bool DeleteHardwareAssetById(int hardwareAssetNumber);

        int CreateHardwareAsset(AssetManager_HardwareAsset_vm model, string username);

        int EditHardwareAssetById(int hardwareAssetNumber, AssetManager_HardwareAsset_vm model, string userName);

    }
}
