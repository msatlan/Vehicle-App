using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Models;
using VehicleApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

        public async Task<bool> AddNewVehicleMakeAsync(VehicleMake newVehicleMake)
        {
            newVehicleMake.VehicleMakeId = Guid.NewGuid();
            context.VehicleMakes.Add(newVehicleMake);

            var result = await context.SaveChangesAsync();

            return result == 1;
        }

        public async Task<VehicleMake> FetchVehicleMakeAsync(Guid Id)
        {
            var vehicleMake = await context.VehicleMakes.FirstOrDefaultAsync(vMake => vMake.VehicleMakeId == Id);

            return vehicleMake;
        }

        public async Task<bool> DeleteVehicleMakeAsync(Guid Id)
        {
            var vehicleMakeToDelete = await context.VehicleMakes.FindAsync(Id);

            context.Remove(vehicleMakeToDelete);

            var result = await context.SaveChangesAsync();

            return result == 1;
        }
   
        public async Task<bool> UpdateVehicleMakeAsync(Guid id, string name, string abrv)
        {
            var vehicleMake = await context.VehicleMakes.FindAsync(id);
            vehicleMake.Name = name;
            vehicleMake.Abrv = abrv;
            //vehicleMake.VehicleModels = vehicleModels;

            context.Update(vehicleMake);

            var result = await context.SaveChangesAsync();

            return result == 1;
        }
    }
}
