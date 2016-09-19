using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API.AssetManager
{
    public class HardwareTypeController : ApiController
    {
        private readonly IAssetManagerHardwareTypeManager _assetHardwareTypeManager;
        private readonly ILogger _logger;
        public HardwareTypeController(IAssetManagerHardwareTypeManager assetHardwareTypeManager, ILogger logger)
            {
            _assetHardwareTypeManager = assetHardwareTypeManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AssetManager_HardwareType_vm> Get()
            {
            _logger.Info("Getting all Hardware Types.");
            return _assetHardwareTypeManager.GetAllHardwareTypes();
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]AssetManager_HardwareType_vm value)
            {
            _logger.Info("Creating a new Hardware type.");
            return _assetHardwareTypeManager.CreateHardwareType(value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]AssetManager_HardwareType_vm value)
            {
            _logger.Info("Editing the Hardware type with id "+ id);
            return _assetHardwareTypeManager.EditHardwareTypeById(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the Hardware type with id "+id);
            return _assetHardwareTypeManager.DeleteHardwareTypeById(id);
            }
        }
}
