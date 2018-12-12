using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Models;
using VehicleApp.Models.VehicleMakeViewModels;

namespace VehicleApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateViewModel, VehicleMake>();

            /*
                .ForPath(dest => dest.VehicleMake.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.VehicleMake.Name, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.VehicleMake.Abrv, opt => opt.MapFrom(src => src.Abrv))
                .ForPath(dest => dest.VehicleMake.VehicleModels, opt => opt.MapFrom(src => src.VehicleModels))
            */
        }
    }
}
