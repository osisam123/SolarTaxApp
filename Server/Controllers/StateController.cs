using SolarTaxApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarTaxApp.Server.Data;
using SolarTaxApp.Server.Models;

namespace SolarTaxApp.Server.Controllers
{
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly ILogger<StateController> logger;
        private IStateData _state;
        public StateController(ILogger<StateController> logger, IStateData state)
        {
            this.logger = logger;
            this._state = state;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetState()
        {
            return Ok(_state.GetState());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetState(string id)
        {
            var state = _state.GetState(id);
            if (state != null)
                return Ok(state);
            else
                return NotFound($"The country with id {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddClassification(StateTb state)
        {
            _state.AddState(state);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + state.Stateid, state);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteState(string id)
        {
            var state = _state.GetState(id);
            if (state != null)
            {
                _state.DeleteState(state);
                return Ok();
            }
            return NotFound($"The country with id {id} was not found");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EDitState(string id, [FromBody] StateTb state)
        {
            var Existingstate = _state.GetState(id);
            if (Existingstate != null)
            {
                Existingstate.Code = state.Code;
                Existingstate.Statename = state.Statename;
                Existingstate.Flag = state.Flag;

                _state.EditState(Existingstate);
                return Ok(state);
            }
            return NotFound($"The country with id {id} was not found");
        }
    }
}
