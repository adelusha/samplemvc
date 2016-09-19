using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDeskSVC.Domain.Utilities
{
    public enum TicketPriorityEnum
    {
        [Description("Unable to Work")]
        UnableToWork = 0,
        [Description("High")]
        High = 1,
        [Description("Medium")]
        Medium = 2,
        [Description("Low")]
        Low = 3,
    }
}
