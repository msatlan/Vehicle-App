using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleApp.Models.VehicleMakeViewModels
{
    public class EditViewModel
    {
        public VehicleMake VehicleMakeToEdit { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleModel[] VehicleModels { get; set; }
    }
}
