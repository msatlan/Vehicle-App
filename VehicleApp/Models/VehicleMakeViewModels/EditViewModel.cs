using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleApp.Models.VehicleMakeViewModels
{
    public class EditViewModel
    {
        public Guid Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "Abbreviation")]
        public string Abrv { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
