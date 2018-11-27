using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleApp.Models.VehicleMakeViewModels
{
    public class DeleteViewModel
    {
        public Guid Id { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}
