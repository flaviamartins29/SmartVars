using SmartVars.Application.Model;
using SmartVars.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Application.Interface
{
    public interface IBuidingVars
    {
        Task<BuildingVarsResultsServices<BuildingVarsModel>> CreatAsync(BuildingVarsModel model);

        //Task<BuildingVarsResultsServices<BuildingVarsModel>> CreatAsync(BuildingVarsModel model);
    }
}
