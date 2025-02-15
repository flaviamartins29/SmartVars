using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartVars.Application.Model;
using SmartVars.Application.Services;
using SmartVars.Application.Services.Interface;
using SmartVars.Infra.Data.Context;

namespace SmartVarsController.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartVarsController : ControllerBase
    {
        private readonly IBuildingVarsServices _buidingVars;

        public SmartVarsController(IBuildingVarsServices buidingVars)
        {
            _buidingVars = buidingVars;

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BuildingVarsModel varModel)
        {
            var result = await _buidingVars.CreatAsync(varModel);
            if (result.IsSucsess)
                return Ok(result);

            return BadRequest(result);

        }

    }
}
