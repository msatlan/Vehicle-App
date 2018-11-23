using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Services;
using VehicleApp.Models.VehicleMakeViewModels;
using VehicleApp.Models;


namespace VehicleApp.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleService vehicleService;

        public  VehicleMakeController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        public async Task<IActionResult> Index()
        {
            var vehicleMakes = await vehicleService.GetVehicleMakesAsync();

            var viewModel = new IndexViewModel();

            viewModel.VehicleMakes = vehicleMakes;

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddNewVehicleMake(VehicleMake newVehicleMake)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            var success = await vehicleService.AddNewVehicleMakeAsync(newVehicleMake);
            if (!success) return BadRequest("Could not add new vehicle make");
           
            return RedirectToAction("Index");
        }
    }
}
