using AutoMapper;
using PlateformService.Dtos;
using PlateformService.Models;

namespace PlateformService.Profiles
{
    public class PlateformsProfile : Profile
    {
        public PlateformsProfile()
        {
            CreateMap<PlateformCreateDto, Plateform>();
            CreateMap<Plateform, PlateformReadDto>();
        }
    }
}
