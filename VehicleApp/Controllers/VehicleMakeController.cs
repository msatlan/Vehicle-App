using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Services;
using VehicleApp.Models.VehicleMakeViewModels;
using VehicleApp.Models;
using System.Diagnostics;

namespace VehicleApp.Controllers
{
    public class VehicleMakeController : Controller
    {
        // Properties
        private readonly IVehicleService vehicleService;

        // Constructor
        public VehicleMakeController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        // Fetch array of Vehicle Makes
        public async Task<IActionResult> Index()
        {
            var vehicleMakes = await vehicleService.GetVehicleMakesAsync();

            var viewModel = new IndexViewModel();

            viewModel.VehicleMakes = vehicleMakes;

            return View(viewModel);
        }

        // Navigate to Create page
        public IActionResult Create()
        {
            return View();
        }

        // Add new Vehicle Make
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddNewVehicleMake(VehicleMake newVehicleMake)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            var success = await vehicleService.AddNewVehicleMakeAsync(newVehicleMake);
            if (!success) return BadRequest("Could not add new vehicle make");

            return RedirectToAction("Index");
        }

        // Navigate to Delete page and display selected vehicle
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) return NotFound();

            var vehicleMake = await vehicleService.FetchVehicleMakeAsync(id);

            var viewModel = new DeleteViewModel() { VehicleMakeToDelete = vehicleMake };

            return View(viewModel);
        }

        // Delete selected Vehicle Make
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteVehicleMake(Guid id)
        {
            var success = await vehicleService.DeleteVehicleMakeAsync(id);
            if (!success) return BadRequest("Could not delete Vehicle Make.");

            return RedirectToAction("Index");
        }

        // Navigate to Edit page and display selected Vehicle Make
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null) return NotFound();

            var vehicleMake = await vehicleService.FetchVehicleMakeAsync(id);

            var viewModel = new EditViewModel() { VehicleMakeToEdit = vehicleMake };

            return View(viewModel);
        }

        // Update database
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UpdateVehicleMake(Guid id, EditViewModel viewModel) 
        {
            var success = await vehicleService.UpdateVehicleMakeAsync(id, viewModel.VehicleMakeToEdit.Name, viewModel.VehicleMakeToEdit.Abrv);
            if (!success) return BadRequest("Could not update Vehicle Make.");

            return RedirectToAction("Index");
        }
    }
}
