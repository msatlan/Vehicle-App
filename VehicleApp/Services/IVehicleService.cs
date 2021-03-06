﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Models;

namespace VehicleApp.Services
{
    public interface IVehicleService
    {
        Task<List<VehicleMake>> FetchVehicleMakesAsync();
        //Task<List<VehicleMake>> FetchPagedVehicleMakes(string sortOrder, string searchString, int pageIndex, int pageSize);
        Task<bool> AddNewVehicleMakeAsync(VehicleMake newVehicleMake);
        Task<VehicleMake> FetchVehicleMakeAsync(Guid id);
        Task<bool> DeleteVehicleMakeAsync(Guid id);
        Task<bool> UpdateVehicleMakeAsync(VehicleMake vehicleMake);
    }
}
