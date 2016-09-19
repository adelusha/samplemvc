using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.AssetManager
    {
    public interface IAssetManagerModelsRepository
    {
        List<AssetManager_Models> GetAllModels();

        bool DeleteModels(int id);

        int CreateModel(AssetManager_Models model);

        int EditModel(int id, AssetManager_Models model);
        }
    }
