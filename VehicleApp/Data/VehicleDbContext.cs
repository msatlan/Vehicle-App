using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// added
using Microsoft.EntityFrameworkCore;
using VehicleApp.Models;

namespace VehicleApp.Data
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) 
        {
        }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>().HasData(
                new VehicleMake { VehicleMakeId = 1, Name = "Zastava", Abrv = "Zst" },
                new VehicleMake { VehicleMakeId = 2, Name = "Renault", Abrv = "Rnt" },
                new VehicleMake { VehicleMakeId = 3, Name = "Trabant", Abrv = "Trb" }
            );

            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel { VehicleModelId = 1, Name = "Yugo45", Abrv = "Y", VehicleMakeID = 1 },
                new VehicleModel { VehicleModelId = 2, Name = "750", Abrv = "F", VehicleMakeID = 1 },
                new VehicleModel { VehicleModelId = 3, Name = "4", Abrv = "4", VehicleMakeID = 2 },
                new VehicleModel { VehicleModelId = 4, Name = "Clio", Abrv = "C", VehicleMakeID = 2 },
                new VehicleModel { VehicleModelId = 5, Name = "601", Abrv = "6", VehicleMakeID = 3 }
            );
        }
    }
}
