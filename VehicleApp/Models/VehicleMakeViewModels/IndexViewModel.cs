using System;
using System.Collections.Generic;
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
        public void SortVehicleMakes(IEnumerable<VehicleMake> vehicleMakes, string sortOrder)
        {
            var sortedList = new List<VehicleMake>();

            switch (sortOrder)
            {
                case "name_desc":
                    sortedList = vehicleMakes.OrderByDescending(v => v.Name).ToList();
                    break;
                case "Abrv":
                    sortedList = vehicleMakes.OrderBy(v => v.Abrv).ToList();
                    break;
                case "abrv_desc":
                    sortedList = vehicleMakes.OrderByDescending(v => v.Abrv).ToList();
                    break;
                default:
                    sortedList = vehicleMakes.OrderBy(v => v.Name).ToList();
                    break;
            }

            this.VehicleMakes = sortedList;
        }
    }
}
