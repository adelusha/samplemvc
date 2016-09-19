using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServiceDeskSVC.Domain.Entities.ViewModels.AssetManager
    {
    public class AssetManager_Companies_vm
        {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Website { get; set; }

        [MaxLength(30)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public string Street { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(2)]
        public string State { get; set; }

        [MaxLength(10)]
        public string Zip { get; set; }
        }
    }
