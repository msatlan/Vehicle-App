using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleApp.Models
{
    public class VehicleModel
    {
        public int VehicleModelId { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Abrv { get; set; }

        // Foreign key
        public int VehicleMakeID { get; set; }

        // Navigation property
        public VehicleMake VehicleMake { get; set; }
    }
}

