using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager
{
    public class AssetManager_HardwareType_vm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionNotes { get; set; }
        public int? EndOfLifeMo { get; set; }
        public int CategoryCode { get; set; }
    }
}
