using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Services;
using VehicleApp.Models;
using VehicleApp.Models.VehicleMakeViewModels;
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
        
        // Fetch list of Vehicle Makes
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParameter"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AbrvSortParameter"] = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";
            ViewData["SearchParameter"] = searchString;

            var vehicleMakes = new List<VehicleMake>();

            if (String.IsNullOrEmpty(searchString)) {
                vehicleMakes = await vehicleService.FetchVehicleMakesAsync();
            } else {
                vehicleMakes = await vehicleService.SearchVehicleMakesAsync(searchString);
            }

            var viewModel = new IndexViewModel();

            viewModel.VehicleMakes = viewModel.SortVehicleMakes(vehicleMakes, sortOrder);

            return View(viewModel);
        }

        // Navigate to Create page
        public IActionResult Create()
        {
            return View();
        }

        // Add new Vehicle Make       
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddNewVehicleMake( VehicleMake newVehicleMake)
        {
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("--------------------> ModelState invalid!!!!");
                return RedirectToAction("Create");
            }

            var success = await vehicleService.AddNewVehicleMakeAsync(newVehicleMake);
            if (!success) return BadRequest("Could not add new vehicle make");

            return RedirectToAction("Index");
        }

        // Navigate to Delete page and display selected vehicle
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) return NotFound();

            var vehicleMakeToDelete = await vehicleService.FetchVehicleMakeAsync(id);

            var viewModel = new DeleteViewModel() { VehicleMake = vehicleMakeToDelete };

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

        // Navigate to Details page and display selected Vehicle Make
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null) return NotFound();

            var vehicleMake = await vehicleService.FetchVehicleMakeAsync(id);

            var viewModel = new DetailsViewModel() { VehicleMake = vehicleMake, Id = id };

            return View(viewModel);
        }

        // Navigate to Edit page and display selected Vehicle Make
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null) return NotFound();

            var vehicleMakeToEdit = await vehicleService.FetchVehicleMakeAsync(id);

            var viewModel = new EditViewModel() { VehicleMake = vehicleMakeToEdit };

            return View(viewModel);
        }

        // Update database
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UpdateVehicleMake(Guid id, EditViewModel viewModel) 
        {
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("--------------------> ModelState invalid!!!!");
                return RedirectToAction("Edit");
            }

            var success = await vehicleService.UpdateVehicleMakeAsync(id, viewModel.VehicleMake.Name, viewModel.VehicleMake.Abrv);
            if (!success) return BadRequest("Could not update Vehicle Make.");

            return RedirectToAction("Index");
        }
    }
}
