using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;

namespace ServiceDeskSVC.Managers
{
    public interface IAssetManagerModelsManager
        {
        List<AssetManager_Models_vm> GetAllModels();

        bool DeleteModelById(int id);

        int CreateModel(AssetManager_Models_vm model);

        int EditModelById(int id, AssetManager_Models_vm model);

        }
}
