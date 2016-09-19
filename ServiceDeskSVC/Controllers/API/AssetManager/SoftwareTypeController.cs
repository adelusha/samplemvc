using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API.AssetManager
{
    public class SoftwareTypeController : ApiController
    {
        private readonly IAssetManagerSoftwareTypeManager _assetSoftwareTypeManager;
        private readonly ILogger _logger;
        public SoftwareTypeController(IAssetManagerSoftwareTypeManager assetSoftwareTypeManager, ILogger logger)
            {
            _assetSoftwareTypeManager = assetSoftwareTypeManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AssetManager_SoftwareType_vm> Get()
            {
            _logger.Info("Getting all Software Types.");
            return _assetSoftwareTypeManager.GetAllSoftwareTypes();
            }

        public AssetManager_SoftwareType_vm Get(int id)
            {
            _logger.Info("Getting single Software Asset Type with ID of " + id);
            return _assetSoftwareTypeManager.GetSoftwareAssetTypeByID(id);
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]AssetManager_SoftwareType_vm value)
            {
            _logger.Info("Creating a new software type.");
            return _assetSoftwareTypeManager.CreateSoftwareType(value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]AssetManager_SoftwareType_vm value)
            {
            _logger.Info("Editing the software type with id "+ id);
            return _assetSoftwareTypeManager.EditSoftwareTypeById(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the software type with id "+id);
            return _assetSoftwareTypeManager.DeleteSoftwareTypeById(id);
            }
        }
}
