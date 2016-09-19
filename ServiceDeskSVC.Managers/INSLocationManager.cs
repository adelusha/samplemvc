using System.Collections.Generic;
using ServiceDeskSVC.Domain.Entities.ViewModels;
using ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets;

namespace ServiceDeskSVC.Managers
{
    public interface INSLocationManager
    {
        List<NSLocation_vm> GetAllLocations();

        bool DeleteLocationById(int id);

        int CreateLocation(NSLocation_vm location);

        int EditLocationById(int id, NSLocation_vm location);        
    }
}
