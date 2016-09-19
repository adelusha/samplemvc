using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager
{
    public class AssetManager_Models_vm
    {
    public int Id { get; set; }
    public string ModelName { get; set; }
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string DescriptionNotes { get; set; }
    public string SupportWebsite { get; set; }
    public string ManufacturerWebsite { get; set; }
    //public virtual ICollection<AssetManager_AssetAttachments> AssetManager_AssetAttachments { get; set; }
    public virtual AssetManager_Models_Company AssetManager_Companies { get; set; }
    //public virtual ICollection<AssetManager_Hardware> AssetManager_Hardware { get; set; }
    }

    public class AssetManager_Models_Company
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }
    }
}
