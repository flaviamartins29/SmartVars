using SmartVars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Domain.Repository
{
    public interface IBuildingVarsRepository : IDisposable
    {
        Task<BuildingVars> GetVarByIdAsync(int id);
        Task<ICollection<BuildingVars>> GetAllVarsListAsync();
        Task<BuildingVars> CreateNewVarsAsync(BuildingVars buildingVars);
        Task UpdateVarByIdAsync(BuildingVars buildingVars);
        Task DeleteVarByIdAsync(BuildingVars buildingVars);

    }
}
