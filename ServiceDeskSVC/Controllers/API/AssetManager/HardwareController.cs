using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;
using ServiceDeskSVC.Managers;
using ServiceDeskSVC.Managers.AssetManager;

namespace ServiceDeskSVC.Controllers.API.AssetManager
{
    public class HardwareController : ApiController
    {
        private readonly IAssetManagerHardwareAssetManager _assetHardwareManager;
        private readonly ILogger _logger;
        public HardwareController(IAssetManagerHardwareAssetManager assetHardwareManager, ILogger logger)
        {
            _assetHardwareManager = assetHardwareManager;
            _logger = logger;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AssetManager_HardwareAsset_View_vm> Get()
        {
            _logger.Info("Getting all Hardware Assets.");
            return _assetHardwareManager.GetAllHardwareAssets();
        }


        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public AssetManager_HardwareAsset_View_vm Get(int id)
        {
            _logger.Info("Getting single Hardware Asset with ID of " + id);
            return _assetHardwareManager.GetHardwareAssetById(id);
        }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int Post([FromBody]AssetManager_HardwareAsset_vm value, string userName)
        {
            _logger.Info("Creating a new Hardware Asset.");
            return _assetHardwareManager.CreateHardwareAsset(value, userName);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int Put(int id, [FromBody]AssetManager_HardwareAsset_vm value, string userName)
        {
            _logger.Info("Editing the Hardware Asset with id of " + id);
            return _assetHardwareManager.EditHardwareAssetById(id, value, userName);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            _logger.Info("Deleting the Hardware type with id of " + id);
            return _assetHardwareManager.DeleteHardwareAssetById(id);
        }
    }
}
