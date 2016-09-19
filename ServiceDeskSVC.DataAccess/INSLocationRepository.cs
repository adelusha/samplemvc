using System.Collections.Generic;
using ServiceDeskSVC.DataAccess.Models;

namespace ServiceDeskSVC.DataAccess
{
    public interface INSLocationRepository
    {
        List<NSLocation> GetAllLocations();

        bool DeleteLocationById(int id);

        int CreateLocation(NSLocation location);

        int EditLocationByID(int id, NSLocation location);
    }
}
