using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Models;

namespace VehicleApp.Services
{
    public interface IVehicleService
    {
        Task<VehicleMake[]> GetVehicleMakesAsync();
        Task<bool> AddNewVehicleMakeAsync(VehicleMake newVehicleMake);
        Task<VehicleMake> FetchVehicleMakeAsync(Guid Id);
        Task<bool> DeleteVehicleMakeAsync(Guid Id);
        Task<bool> UpdateVehicleMakeAsync(Guid id, string name, string abrv);
    }
}
