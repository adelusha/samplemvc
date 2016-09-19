using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDeskSVC.Domain.Entities.ViewModels
{
    public class NSLocation_vm
    {
        public int Id { get; set; }

        public string LocationCity { get; set; }

        public string LocationState { get; set; }

        public int LocationZip { get; set; }
    }
}
