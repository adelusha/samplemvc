using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API.AssetManager
{
    public class ModelsController : ApiController
    {
        private readonly IAssetManagerModelsManager _assetModelsManager;
        private readonly ILogger _logger;
        public ModelsController(IAssetManagerModelsManager assetModelsManager, ILogger logger)
            {
            _assetModelsManager = assetModelsManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AssetManager_Models_vm> Get()
            {
            _logger.Info("Getting all models.");
            return _assetModelsManager.GetAllModels();
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]AssetManager_Models_vm value)
            {
            _logger.Info("Creating a new model.");
            return _assetModelsManager.CreateModel(value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]AssetManager_Models_vm value)
            {
            _logger.Info("Editing the model with id "+ id);
            return _assetModelsManager.EditModelById(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the model with id "+id);
            return _assetModelsManager.DeleteModelById(id);
            }
        }
}
