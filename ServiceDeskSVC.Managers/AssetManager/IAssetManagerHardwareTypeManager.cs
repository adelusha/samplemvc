using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;

namespace ServiceDeskSVC.Managers
{
    public interface IAssetManagerHardwareTypeManager
        {
        List<AssetManager_HardwareType_vm> GetAllHardwareTypes();

        bool DeleteHardwareTypeById(int id);

        int CreateHardwareType(AssetManager_HardwareType_vm HardwareType);

        int EditHardwareTypeById(int id, AssetManager_HardwareType_vm HardwareType);

        }
}
