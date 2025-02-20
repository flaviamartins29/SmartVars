using SmartVars.Application.ViewModel;
using SmartVars.Domain.Validations;

namespace SmartVars.Application.Services.Interfaces
{
    public interface IBuildingVarsServices
    {
        Task<BuildingVarsResults<BuildingVarsViewModel>> CreateAsync(BuildingVarsViewModel model);
        Task<BuildingVarsResults<ICollection<BuildingVarsViewModel>>> GetAsync();
        Task<BuildingVarsResults<BuildingVarsViewModel>> GetByIdAsync(int id);
        Task<BuildingVarsResults> UpdateAsync(BuildingVarsViewModel model);
    }
}
