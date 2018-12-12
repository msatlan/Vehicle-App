using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Services;
using VehicleApp.Models;
using VehicleApp.Models.VehicleMakeViewModels;
using System.Diagnostics;
using AutoMapper;

namespace VehicleApp.Controllers
{
    public class VehicleMakeController : Controller
    {
        // Properties
        private readonly IVehicleService vehicleService;
        private readonly IMapper mapper;

        // Constructor
        public VehicleMakeController(IVehicleService vehicleService, IMapper mapper)
        {
            this.vehicleService = vehicleService;
            this.mapper = mapper;
        }
        
        // Fetch list of Vehicle Makes
        public async Task<IActionResult> Index()
        {
            var vehicleMakes = await vehicleService.FetchVehicleMakesAsync();

            IndexViewModel viewModel = new IndexViewModel() { VehicleMakes = mapper.Map<List<VehicleMake>>(vehicleMakes) };

            return View(viewModel);
        }

        /*
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewData["NameSortParameter"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AbrvSortParameter"] = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";
            ViewData["CurrentSort"] = sortOrder;

            if (searchString == null)
            {
                searchString = currentFilter;
            } 

            ViewData["CurrentFilter"] = searchString;

            var pageSize = 4;
            var viewModel = await vehicleService.FetchPagedVehicleMakes(sortOrder, searchString, page ?? 1, pageSize);

            return View(viewModel);
        }
        */

        // Navigate to Create page
        public IActionResult Create()
        {
            return View();
        }

        // Add new Vehicle Make       
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddNewVehicleMake()
        {
            CreateViewModel viewModel = new CreateViewModel() { Id = Guid.NewGuid(), Name = "VMAKE", Abrv = "33" };

            VehicleMake vehicleMakeToAdd = mapper.Map<VehicleMake>(viewModel);

            if (!ModelState.IsValid)
            {
                Debug.WriteLine("--------------------> ModelState invalid!");
                return RedirectToAction("Create");
            }

            var success = await vehicleService.AddNewVehicleMakeAsync(vehicleMakeToAdd);
            if (!success) return BadRequest("Could not add new vehicle make");

            return RedirectToAction("Index");
        }

        // Navigate to Delete page and display selected vehicle
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) return NotFound();

            DeleteViewModel viewModel = mapper.Map<DeleteViewModel>(await vehicleService.FetchVehicleMakeAsync(id));

            var success = await vehicleService.DeleteVehicleMakeAsync(viewModel.Id);

            if (!success) return BadRequest("Could not delete Vehicle Make.");

            return RedirectToAction("Index");
        }

        // Navigate to Details page and display selected Vehicle Make
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null) return NotFound();

            DetailsViewModel viewModel = mapper.Map<DetailsViewModel>(await vehicleService.FetchVehicleMakeAsync(id));

            return View(viewModel);
        }

        // Navigate to Edit page and display selected Vehicle Make
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null) return NotFound();

            var vehicleMakeToEdit = await vehicleService.FetchVehicleMakeAsync(id);

            EditViewModel viewModel = mapper.Map<EditViewModel>(vehicleMakeToEdit);

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

            VehicleMake vehicleMakeToEdit = mapper.Map<VehicleMake>(viewModel);

            var success = await vehicleService.UpdateVehicleMakeAsync(vehicleMakeToEdit);
            if (!success) return BadRequest("Could not update Vehicle Make.");

            return RedirectToAction("Index");
        }
    }
}
