using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API.AssetManager
{
    public class SoftwareController : ApiController
    {
        private readonly IAssetManagerSoftwareManager _assetSoftwareManager;
        private readonly ILogger _logger;
        public SoftwareController(IAssetManagerSoftwareManager assetSoftwareManager, ILogger logger)
            {
            _assetSoftwareManager = assetSoftwareManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AssetManager_Software_View_vm> Get()
            {
            _logger.Info("Getting all Software assets.");
            return _assetSoftwareManager.GetAllSoftwareAssets();
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public AssetManager_Software_vm Get(int id)
            {
            _logger.Info("Getting single Software Asset with ID of " + id);
            return _assetSoftwareManager.GetSoftwareAssetByID(id);
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]AssetManager_Software_vm value)
            {
            _logger.Info("Creating a new software asset.");
            return _assetSoftwareManager.CreateSoftwareAsset(value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]AssetManager_Software_vm value)
            {
            _logger.Info("Editing the software asset with id "+ id);
            return _assetSoftwareManager.EditSoftwareAssetById(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the software asset with id "+id);
            return _assetSoftwareManager.DeleteSoftwareAssetById(id);
            }
        }
}
