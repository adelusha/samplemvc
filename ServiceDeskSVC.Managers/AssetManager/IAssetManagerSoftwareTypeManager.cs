using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;

namespace ServiceDeskSVC.Managers
{
    public interface IAssetManagerSoftwareTypeManager
        {
        List<AssetManager_SoftwareType_vm> GetAllSoftwareTypes();

        AssetManager_SoftwareType_vm GetSoftwareAssetTypeByID(int id);

        bool DeleteSoftwareTypeById(int id);

        int CreateSoftwareType(AssetManager_SoftwareType_vm softwareType);

        int EditSoftwareTypeById(int id, AssetManager_SoftwareType_vm softwareType);

        }
}
