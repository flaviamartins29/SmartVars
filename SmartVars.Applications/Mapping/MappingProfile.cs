using AutoMapper;
using SmartVars.Domain.Entities;
using SmartVars.Application.Model;

namespace SmartVars.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BuildingVars, BuildingVarsModel>().ReverseMap();
        }
    }
}
