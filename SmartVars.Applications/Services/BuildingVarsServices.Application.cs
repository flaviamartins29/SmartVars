using AutoMapper;
using SmartVars.Application.Model;
using SmartVars.Application.Notification;
using SmartVars.Application.Services.Interface;
using SmartVars.Application.Validation;
using SmartVars.Domain.Entities;
using SmartVars.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Application.Services
{
    public class BuildingVarsServices : IBuildingVarsServices
    {
        private readonly IBuildingVarsRepository _buildingVarsRepository;
        private readonly IMapper _mapper;

        public BuildingVarsServices(IBuildingVarsRepository varsRepository, IMapper mapper) 
        {
            _buildingVarsRepository = varsRepository;
            _mapper = mapper;
        }
        public async Task<BuildingVarsResultsServices<BuildingVarsModel>> CreatAsync(BuildingVarsModel varsModel)
        {
            if (varsModel == null)
                return BuildingVarsResultsServices.Fail<BuildingVarsModel>("Null fields are not accepted. Please ensure all fields are filled.");

            var result = new BuildingVarsValidateError().Validate(varsModel);
            if (!result.IsValid)
                return BuildingVarsResultsServices.RequestError<BuildingVarsModel>("Your Request is invalid, please enter the vulueType correct.", result);

            var valueType = _mapper.Map<BuildingVars>(varsModel); 
            var data = await _buildingVarsRepository.CreateNewVarsAsync(valueType);

            return BuildingVarsResultsServices.Sucess(_mapper.Map<BuildingVarsModel>(data)); 
        }
    }
    
}
