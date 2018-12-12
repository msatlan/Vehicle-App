using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace VehicleApp.Models
{
    public class VehicleMake
    {
        public Guid Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "Abbreviation")]
        public string Abrv { get; set; }

        // Navigation property
        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
