using AutoMapper;
using SmartVars.Application.ViewModel;
using SmartVars.Domain.Entities;

namespace SmartVars.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BuildingVars, BuildingVarsViewModel>().ReverseMap();
        }
    }
}
