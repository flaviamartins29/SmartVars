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

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _buidingVars.GetAsync();
            if (result.IsSucsess)
                return Ok(result);

            return BadRequest(result);

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAll(int id)
        {
            var result = await _buidingVars.GetByIdAsync(id);
            if (result.IsSucsess)
                return Ok(result);

            return BadRequest(result);

        }

    }
}
