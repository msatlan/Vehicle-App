using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleApp.Models;

namespace VehicleApp.Data
{
    public class VehicleDbContext : DbContext
    {
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) 
        {
        }
    }
}
