using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
    {
    public interface IAssetManagerHardwareAssetTypeRepository
    {
        List<AssetManager_Hardware_AssetType> GetAllHardwareAssetTypes();

        bool DeleteHardwareAssetTypes(int id);

        int CreateHardwareAssetTypes(AssetManager_Hardware_AssetType HardwareType);

        int EditHardwareAssetTypes(int id, AssetManager_Hardware_AssetType HardwareType);
        }
    }
