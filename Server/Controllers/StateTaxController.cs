using SolarTaxApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarTaxApp.Server.Data;
using SolarTaxApp.Server.Models;
using SolarTaxApp.Shared.Models;

namespace SolarTaxApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateTaxController : ControllerBase
    {
        private readonly ILogger<StateTaxController> logger;
        private IStateTaxData _stateTax;
        public StateTaxController(ILogger<StateTaxController> logger, IStateTaxData stateTax)
        {
            this.logger = logger;
            this._stateTax = stateTax;
        }

        [HttpGet("alltax")]
        public IActionResult GetStateTax()
        {
            return Ok(_stateTax.GetStateTax());
        }

        [HttpGet("onetax/{id}")]
        public IActionResult GetStateTax(string id)
        {
            var stateTax = _stateTax.GetStateTax(id);
            if (stateTax != null)
                return Ok(stateTax);
            else
                return NotFound($"The tax with id {id} was not found");
        }

        [HttpGet("gettax/{search}")]        
        public IActionResult GetStateTaxSearch(string search)
        {
            var stateTax = _stateTax.GetStateTaxSearch(search);
            if (stateTax != null)
                return Ok(stateTax);
            else
                return NotFound($"The search item {search} was not found");
        }

        [HttpGet("getmultitax/{search}")]
        public IActionResult GetMultiStateTaxSearch(string search)
        {
            var stateTax = _stateTax.GetMultiStateTaxSearch(search);
            if (stateTax != null)
                return Ok(stateTax);
            else
                return NotFound($"The search item {search} was not found");
        }
    }
}
