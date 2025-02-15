using SmartVars.Application.Model;
using SmartVars.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Application.Services.Interface
{
    public interface IBuildingVarsServices
    {
        Task<BuildingVarsResultsServices<BuildingVarsModel>> CreatAsync(BuildingVarsModel model);

    }
}
