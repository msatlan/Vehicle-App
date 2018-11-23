using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Models;
using VehicleApp.Data;
using Microsoft.EntityFrameworkCore;

namespace VehicleApp.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleDbContext context;

        public VehicleService(VehicleDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddNewVehicleMakeAsync(VehicleMake newVehicleMake)
        {
            newVehicleMake.VehicleMakeId = Guid.NewGuid();

            context.VehicleMakes.Add(newVehicleMake);

            var result = await context.SaveChangesAsync();

            return result == 1;
        }

        public async Task<VehicleMake[]> GetVehicleMakesAsync()
        {
            return await context.VehicleMakes.ToArrayAsync();
        }
    }
}
