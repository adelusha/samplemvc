using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API
    {
    public class CompaniesController:ApiController
        {
        private readonly IAssetManagerCompaniesManager _assetCompaniesManager;
        private readonly ILogger _logger;
        public CompaniesController(IAssetManagerCompaniesManager assetCompaniesManager, ILogger logger)
            {
            _assetCompaniesManager = assetCompaniesManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AssetManager_Companies_vm> Get()
            {
            _logger.Info("Getting all Companies.");
            return _assetCompaniesManager.GetAllCompanies();
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]AssetManager_Companies_vm value)
            {
            _logger.Info("Creating a new company.");
            return _assetCompaniesManager.CreateCompany(value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]AssetManager_Companies_vm value)
            {
            _logger.Info("Editing the company with id " + id);
            return _assetCompaniesManager.EditCompanyById(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the company with id " + id);
            return _assetCompaniesManager.DeleteCompanyById(id);
            }
        }
    }
