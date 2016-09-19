using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
    {
    public interface IAssetManagerSoftwareAssetTypeRepository
    {
        List<AssetManager_Software_AssetType> GetAllSoftwareAssetTypes();

        AssetManager_Software_AssetType GetSoftwareAssetTypeByID(int id);

        bool DeleteSoftwareAssetTypes(int id);

        int CreateSoftwareAssetTypes(AssetManager_Software_AssetType softwareType);

        int EditSoftwareAssetTypes(int id, AssetManager_Software_AssetType softwareType);
        }
    }
