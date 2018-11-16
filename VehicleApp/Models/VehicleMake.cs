using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VehicleApp.Models
{
    public class VehicleMake
    {
        public int VehicleMakeId { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9'\s-]*$"), Required, StringLength(20)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Abrv { get; set; }

        // Navigation property
        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
