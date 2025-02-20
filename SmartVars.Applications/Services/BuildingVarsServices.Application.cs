using AutoMapper;
using SmartVars.Application.Services.Interfaces;
using SmartVars.Application.Shared;
using SmartVars.Application.ViewModel;
using SmartVars.Domain.Entities;
using SmartVars.Domain.Repository.Services;
using SmartVars.Domain.Validations;

namespace SmartVars.Application.Services
{
    public class BuildingVarsServices : IBuildingVarsServices
    {
        private bool _disposed = false;
        private readonly IBuildingVarsRepository _buildingVarsRepository;
        private readonly IMapper _mapper;

        public BuildingVarsServices(IBuildingVarsRepository varsRepository, IMapper mapper)
        {
            _buildingVarsRepository = varsRepository;
            _mapper = mapper;
        }
        public async Task<BuildingVarsResults<BuildingVarsViewModel>> CreateAsync(BuildingVarsViewModel varsModel)
        {
            if (varsModel == null)
                return BuildingVarsResults.Fail<BuildingVarsViewModel>("Null fields are not accepted. Please ensure all fields are filled.");

            var stringResult = varsModel.MyString;
            if (stringResult == null)
                varsModel.MyString = "";

            var result = new BuildingVarsValidateError().Validate(varsModel);
            if (!result.IsValid)
                return BuildingVarsResults.RequestError<BuildingVarsViewModel>("Your Request is invalid, please enter the vulueType correct.", result);


            var valueType = _mapper.Map<BuildingVars>(varsModel);
            var data = await _buildingVarsRepository.CreateVarsAsync(valueType);

            return BuildingVarsResults.Sucess(_mapper.Map<BuildingVarsViewModel>(data));
        }

        public async Task<BuildingVarsResults<ICollection<BuildingVarsViewModel>>> GetAsync()
        {
            var allVars = await _buildingVarsRepository.GetVarsListAsync();
            return BuildingVarsResults.Sucess<ICollection<BuildingVarsViewModel>>(_mapper.Map<ICollection<BuildingVarsViewModel>>(allVars));

        }

        public async Task<BuildingVarsResults<BuildingVarsViewModel>> GetByIdAsync(int id)
        {
            var idVars = await _buildingVarsRepository.GetVarByIdAsync(id);
            if (idVars == null)
                return BuildingVarsResults.Fail<BuildingVarsViewModel>("Id not found.");

            return BuildingVarsResults.Sucess(_mapper.Map<BuildingVarsViewModel>(idVars));
        }

        public async Task<BuildingVarsResults> UpdateAsync(BuildingVarsViewModel model)
        {
            if (model == null)
                return BuildingVarsResults.Fail("Data are riqueride for delete");

            var validation = new BuildingVarsValidateError().Validate(model);
            if (!validation.IsValid)
                return BuildingVarsResults.RequestError<BuildingVarsViewModel>("Your Request is invalid, please enter the vulueType correct.", validation);

            var varUpdate = await _buildingVarsRepository.GetVarByIdAsync(model.Id);
            if (varUpdate == null)
                return BuildingVarsResults.Fail<BuildingVarsViewModel>("Id not found.");

            varUpdate = _mapper.Map<BuildingVarsViewModel, BuildingVars>(model, varUpdate);

            await _buildingVarsRepository.UpdateVarByIdAsync(varUpdate);
            return BuildingVarsResults.Sucess($"The {varUpdate.Id} was edited");
        }

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Liberar recursos gerenciados
                    if (_buildingVarsRepository is IDisposable disposableRepository)
                    {
                        disposableRepository.Dispose();
                    }

                    if (_mapper is IDisposable disposableMapper)
                    {
                        disposableMapper.Dispose();
                    }
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}


