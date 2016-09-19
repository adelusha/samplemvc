using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.Domain.Entities.ViewModels;

namespace ServiceDeskSVC.Managers.Managers
    {
    public class NSLocationManager:INSLocationManager
        {
        private readonly INSLocationRepository _nsLocationRepository;
        private readonly ILogger _logger;

        public NSLocationManager(INSLocationRepository nsLocationRepository, ILogger logger)
            {
            _nsLocationRepository = nsLocationRepository;
            _logger = logger;
            }

        public List<NSLocation_vm> GetAllLocations()
            {
            var allLocations = _nsLocationRepository.GetAllLocations();
            if(allLocations == null || allLocations.Count == 0)
                {
                _logger.Warn("There are no ticket types.");
                }

            return allLocations.Select(mapEntityToViewModelLocation).ToList();
            }

        public bool DeleteLocationById(int id)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _nsLocationRepository.DeleteLocationById(id);
            }

        public int CreateLocation(NSLocation_vm location)
            {
            return _nsLocationRepository.CreateLocation(mapViewModelToEntityLocation(location));
            }

        public int EditLocationById(int id, NSLocation_vm location)
            {
            if(id == 0)
                {
                throw new ArgumentOutOfRangeException("Id cannot be 0.");
                }

            return _nsLocationRepository.EditLocationByID(id, mapViewModelToEntityLocation(location));
            }

        private NSLocation_vm mapEntityToViewModelLocation(NSLocation EFLocation)
            {
            return new NSLocation_vm
            {
                Id = EFLocation.Id,
                LocationCity = EFLocation.LocationCity,
                LocationState = EFLocation.LocationState,
                LocationZip = EFLocation.LocationZip
            };
            }

        private NSLocation mapViewModelToEntityLocation(NSLocation_vm VMLocation)
            {
            return new NSLocation
            {
                Id = VMLocation.Id,
                LocationCity = VMLocation.LocationCity,
                LocationState = VMLocation.LocationState,
                LocationZip = VMLocation.LocationZip
            };
            }
        }
    }
