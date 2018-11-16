﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleApp.Data;

namespace VehicleApp.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    [Migration("20181116060721_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VehicleApp.Models.VehicleMake", b =>
                {
                    b.Property<int>("VehicleMakeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abrv")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("VehicleMakeId");

                    b.ToTable("VehicleMakes");

                    b.HasData(
                        new { VehicleMakeId = 1, Abrv = "Zst", Name = "Zastava" },
                        new { VehicleMakeId = 2, Abrv = "Rnt", Name = "Renault" },
                        new { VehicleMakeId = 3, Abrv = "Trb", Name = "Trabant" }
                    );
                });

            modelBuilder.Entity("VehicleApp.Models.VehicleModel", b =>
                {
                    b.Property<int>("VehicleModelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abrv")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("VehicleMakeID");

                    b.HasKey("VehicleModelId");

                    b.HasIndex("VehicleMakeID");

                    b.ToTable("VehicleModels");

                    b.HasData(
                        new { VehicleModelId = 1, Abrv = "Y", Name = "Yugo45", VehicleMakeID = 1 },
                        new { VehicleModelId = 2, Abrv = "F", Name = "750", VehicleMakeID = 1 },
                        new { VehicleModelId = 3, Abrv = "4", Name = "4", VehicleMakeID = 2 },
                        new { VehicleModelId = 4, Abrv = "C", Name = "Clio", VehicleMakeID = 2 },
                        new { VehicleModelId = 5, Abrv = "6", Name = "601", VehicleMakeID = 3 }
                    );
                });

            modelBuilder.Entity("VehicleApp.Models.VehicleModel", b =>
                {
                    b.HasOne("VehicleApp.Models.VehicleMake", "VehicleMake")
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleMakeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}