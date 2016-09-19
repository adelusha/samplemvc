using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDeskSVC.Domain.Utilities
{
    public enum AssetManager_DisposalMethodEnum
    {
        [Description("Missing")]
        Missing = 0,
        [Description("Stolen")]
        Stolen = 1,
        [Description("Trashed")]
        Trashed = 2,
        [Description("Donated")]
        Donated = 3,
        [Description("Recycled")]
        Recycled = 4,
    }
}
