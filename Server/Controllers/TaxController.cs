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
    public class TaxController : ControllerBase
    {
        private readonly ILogger<TaxController> logger;
        private ITaxData _tax;
        public TaxController(ILogger<TaxController> logger, ITaxData tax)
        {
            this.logger = logger;
            this._tax = tax;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetTax()
        {
            return Ok(_tax.GetTax());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetTax(string id)
        {            
            var tax = _tax.GetTax(id);
            if (tax != null)
                return Ok(tax);
            else
                return NotFound($"The tax with id {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddTax(TaxTb tax)
        {
            _tax.AddTax(tax);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + tax.Taxid, tax);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteTax(string id)
        {
            var tax = _tax.GetTax(id);
            if (tax != null)
            {
                _tax.DeleteTax(tax);
                return Ok();
            }
            return NotFound($"The tax with id {id} was not found");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EDitTax(string id, [FromBody] TaxTb tax)
        {
            var Existingtax = _tax.GetTax(id);
            if (Existingtax != null)
            {
                Existingtax.Taxcode = tax.Taxcode;
                Existingtax.TaxName = tax.TaxName;

                _tax.EditTax(Existingtax);
                return Ok(tax);
            }
            return NotFound($"The category with id {id} was not found");
        }
    }
}
