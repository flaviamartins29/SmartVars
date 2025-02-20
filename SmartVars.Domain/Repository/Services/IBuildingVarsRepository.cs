using SmartVars.Domain.Entities;

namespace SmartVars.Domain.Repository.Services
{
    public interface IBuildingVarsRepository : IDisposable
    {
        Task<BuildingVars> GetVarByIdAsync(int id);
        Task<ICollection<BuildingVars>> GetVarsListAsync();
        Task<BuildingVars> CreateVarsAsync(BuildingVars buildingVars);
        Task UpdateVarByIdAsync(BuildingVars buildingVars);

    }
}
