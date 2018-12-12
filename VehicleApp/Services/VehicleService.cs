using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Models;
using VehicleApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VehicleApp.Models.VehicleMakeViewModels;


namespace VehicleApp.Services
{
    public class VehicleService : IVehicleService
    {
        // Properties
        private readonly VehicleDbContext context;

        // Constructor
        public VehicleService(VehicleDbContext context)
        {
            this.context = context;
        }

        // Method implementation - Vehicle Make
        public async Task<List<VehicleMake>> FetchVehicleMakesAsync()
        {
            return await context.VehicleMakes.ToListAsync();
        }

        /*
        public async Task<List<VehicleMake>> FetchPagedVehicleMakes(string sortOrder, string searchString, int pageIndex, int pageSize)
        {
            var vehicleMakes = from vehicle in context.VehicleMakes
                               select vehicle;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleMakes = vehicleMakes.Where(vehicleMake => vehicleMake.Name.Contains(searchString) || vehicleMake.Abrv.Contains(searchString) );
            }

            switch (sortOrder)
            {
                case "name_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.Name);
                    break;
                case "Abrv":
                    vehicleMakes = vehicleMakes.OrderBy(v => v.Abrv);
                    break;
                case "abrv_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.Abrv);
                    break;
                default:
                    vehicleMakes = vehicleMakes.OrderBy(v => v.Name);
                    break;
            }

            return await IndexViewModel<VehicleMake>.CreateAsync(vehicleMakes.AsNoTracking(), pageIndex, pageSize);
        }*/

        public async Task<bool> AddNewVehicleMakeAsync(VehicleMake newVehicleMake)
        {
            context.VehicleMakes.Add(newVehicleMake);

            var result = await context.SaveChangesAsync();

            return result == 1;
        }

        public async Task<VehicleMake> FetchVehicleMakeAsync(Guid id)
        {
            var vehicleMake = await context.VehicleMakes.FindAsync(id);

            return vehicleMake;
        }

        public async Task<bool> DeleteVehicleMakeAsync(Guid id)
        {
            //VehicleMake vehicleMakeToDelete = await context.VehicleMakes.FindAsync(id);
            
            VehicleMake vehicleMakeToDelete = context.VehicleMakes
                                               .Where(vehicleMake => vehicleMake.Id == id )
                                               .FirstOrDefault<VehicleMake>();

            context.Remove(vehicleMakeToDelete);

            var result = await context.SaveChangesAsync();

            return result == 1;
        }

        public async Task<bool> UpdateVehicleMakeAsync(VehicleMake vehicleMake)
        {
            context.Update(vehicleMake);

            var result = await context.SaveChangesAsync();

            return result == 1;
        }
    }
}
