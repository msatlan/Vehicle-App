using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleApp.Models.VehicleMakeViewModels
{
    public class IndexViewModel
    {
        // Properties
        public string Name { get; set; }
        public string Abrv { get; set; }

        public List<VehicleMake> VehicleMakes { get; set; }

        // Methods
        public List<VehicleMake> SortVehicleMakes(List<VehicleMake> vehicleMakes, string sortOrder)
        {
            switch (sortOrder)
            {
                case "name_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.Name).ToList();
                    break;
                case "Abrv":
                    vehicleMakes = vehicleMakes.OrderBy(v => v.Abrv).ToList();
                    break;
                case "abrv_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.Abrv).ToList();
                    break;
                default:
                    vehicleMakes = vehicleMakes.OrderBy(v => v.Name).ToList();
                    break;
            }

            return vehicleMakes;
        }
    }
}
