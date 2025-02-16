using AutoMapper;
using SmartVars.Application.Model;
using SmartVars.Application.Notification;
using SmartVars.Application.Services.Interface;
using SmartVars.Application.Validation;
using SmartVars.Domain.Entities;
using SmartVars.Domain.Repository;
using SmartVars.Domain.Validations;
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

            var stringResult = varsModel.MyString;
            if (stringResult == null)
                varsModel.MyString = "";

            var result = new BuildingVarsValidateError().Validate(varsModel);
            if (!result.IsValid)
                return BuildingVarsResultsServices.RequestError<BuildingVarsModel>("Your Request is invalid, please enter the vulueType correct.", result);

            var valueType = _mapper.Map<BuildingVars>(varsModel);
            var data = await _buildingVarsRepository.CreateNewVarsAsync(valueType);

            return BuildingVarsResultsServices.Sucess(_mapper.Map<BuildingVarsModel>(data));
        }

        public async Task<BuildingVarsResultsServices> DeleteAsync(int id)
        {
            var varComplete = await _buildingVarsRepository.GetVarByIdAsync(id);
            if (varComplete == null)
                return BuildingVarsResultsServices.Fail<BuildingVarsModel>("Id not found.");


            await _buildingVarsRepository.DeleteVarByIdAsync(varComplete);
            return BuildingVarsResultsServices.Sucess($"Var {id} deleted whith success");
        }

        public async Task<BuildingVarsResultsServices<ICollection<BuildingVarsModel>>> GetAsync()
        {
            var allVars = await _buildingVarsRepository.GetAllVarsListAsync();
            return BuildingVarsResultsServices.Sucess<ICollection<BuildingVarsModel>>(_mapper.Map<ICollection<BuildingVarsModel>>(allVars));

        }

        public async Task<BuildingVarsResultsServices<BuildingVarsModel>> GetByIdAsync(int id)
        {
            var idVars = await _buildingVarsRepository.GetVarByIdAsync(id);
            if (idVars == null)
                return  BuildingVarsResultsServices.Fail<BuildingVarsModel>("Id not found.");

            return BuildingVarsResultsServices.Sucess(_mapper.Map<BuildingVarsModel>(idVars));
        }

        public async Task<BuildingVarsResultsServices> UpdateAsync(BuildingVarsModel model)
        {
            if (model == null)
                return BuildingVarsResultsServices.Fail("Data are riqueride for delete");

            var validation = new BuildingVarsValidateError().Validate(model);
            if(!validation.IsValid)
                return BuildingVarsResultsServices.RequestError<BuildingVarsModel>("Your Request is invalid, please enter the vulueType correct.", validation);

            var varUpdate = await _buildingVarsRepository.GetVarByIdAsync(model.Id);
            if (varUpdate == null)
                return BuildingVarsResultsServices.Fail<BuildingVarsModel>("Id not found.");

            varUpdate = _mapper.Map<BuildingVarsModel, BuildingVars>(model, varUpdate);

            await _buildingVarsRepository.UpdateVarByIdAsync(varUpdate);
            return BuildingVarsResultsServices.Sucess($"The {varUpdate.Id} was edited");



        }




    }
}


