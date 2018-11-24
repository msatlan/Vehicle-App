using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Models;
using System.ComponentModel.DataAnnotations;

namespace VehicleApp.Models.VehicleMakeViewModels
{
    public class DeleteViewModel
    {
        public VehicleMake VehicleMakeToDelete { get; set; }
        public Guid Id { get; set; }

    }
}
