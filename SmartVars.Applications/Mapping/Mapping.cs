using AutoMapper;
using SmartVars.Application.Model;
using SmartVars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Application.Mapping
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<BuildingVars, BuildingVarsModel>();
        }
    }
}
