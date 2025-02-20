using Microsoft.AspNetCore.Mvc;
using SmartVars.Application.Services.Interfaces;
using SmartVars.Application.ViewModel;

namespace SmartVarsController.Services.Controllers
{
    [Route("api/APISmartVars")]
    [Serializable]
    [ApiController]
    public class SmartVarsController : ControllerBase
    {
        private readonly IBuildingVarsServices _buidingVars;

        public SmartVarsController(IBuildingVarsServices buidingVars)
        {
            _buidingVars = buidingVars;

        }
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] BuildingVarsViewModel varModel)
        {
            var result = await _buidingVars.CreateAsync(varModel);
            if (result.IsSucsess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _buidingVars.GetAsync();
            if (result.IsSucsess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAllAsync(int id)
        {
            var result = await _buidingVars.GetByIdAsync(id);
            if (result.IsSucsess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] BuildingVarsViewModel varModel)
        {
            var result = await _buidingVars.UpdateAsync(varModel);
            if (result.IsSucsess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
