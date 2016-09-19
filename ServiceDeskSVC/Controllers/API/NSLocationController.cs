using System.Collections.Generic;
using System.Web.Http;
using ILogging;
using ServiceDeskSVC.Domain.Entities.ViewModels;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;
using ServiceDeskSVC.Managers;

namespace ServiceDeskSVC.Controllers.API
    {
    public class NSLocationController:ApiController
        {
        private readonly INSLocationManager _nsLocationManager;
        private readonly ILogger _logger;
        public NSLocationController(INSLocationManager nsLocationManager, ILogger logger)
            {
            _nsLocationManager = nsLocationManager;
            _logger = logger;
            }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NSLocation_vm> Get()
            {
            _logger.Info("Getting all locations.");
            return _nsLocationManager.GetAllLocations();
            }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Post([FromBody]NSLocation_vm value)
            {
            _logger.Info("Adding a new location.");
            return _nsLocationManager.CreateLocation(value);
            }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Put(int id, [FromBody]NSLocation_vm value)
            {
            _logger.Info("Editing the location wiht id" + id);
            return _nsLocationManager.EditLocationById(id, value);
            }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
            {
            _logger.Info("Deleting the location with id " + id);
            return _nsLocationManager.DeleteLocationById(id);
            }
        }
    }