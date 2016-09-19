using System;
using System.Collections.Generic;
using System.Linq;
using ILogging;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess.Repositories
    {
    public class NSLocationRepository:INSLocationRepository
        {
        private readonly ServiceDeskContext _context;
        private readonly ILogger _logger;

        public NSLocationRepository(ServiceDeskContext context, ILogger logger)
            {
            _context = context;
            _logger = logger;
            }

        public List<NSLocation> GetAllLocations()
            {
            List<NSLocation> allLocations = _context.NSLocations.ToList();
            return allLocations;
            }

        public bool DeleteLocationById(int id)
            {
            bool result = false;
            try
                {
                NSLocation oldLocation = _context.NSLocations.FirstOrDefault(x => x.Id == id);
                _context.NSLocations.Remove(oldLocation);
                _context.SaveChanges();
                result = true;
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return result;
            }

        public int CreateLocation(NSLocation location)
            {
            _context.NSLocations.Add(location);
            _context.SaveChanges();
            return location.Id;
            }

        public int EditLocationByID(int id, NSLocation location)
            {
            try
                {
                NSLocation oldLocation = _context.NSLocations.FirstOrDefault(x => x.Id == location.Id);
                if(oldLocation != null)
                    {
                    oldLocation.LocationCity = location.LocationCity;
                    oldLocation.LocationState = location.LocationState;
                    oldLocation.LocationZip = location.LocationZip;
                    }
                _context.SaveChanges();
                }
            catch(Exception ex)
                {
                _logger.Error(ex);
                }

            return location.Id;
            }
        }
    }
