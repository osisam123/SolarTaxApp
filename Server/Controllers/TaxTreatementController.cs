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
    public class TaxTreatementController : ControllerBase
    {
        private readonly ILogger<TaxTreatementController> logger;
        private ITaxTreatementData _treatement;
        public TaxTreatementController(ILogger<TaxTreatementController> logger, ITaxTreatementData treatement)
        {
            this.logger = logger;
            this._treatement = treatement;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetTreatement()
        {
            return Ok(_treatement.GetTaxTreatement());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetTreatement(string id)
        {
            var treat = _treatement.GetTaxTreatement(id);
            if (treat != null)
                return Ok(treat);
            else
                return NotFound($"The Tax Treatement with id {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddTreatement(TaxTreatementTb treat)
        {
            _treatement.AddTaxTreatement(treat);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + treat.Id, treat);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteTreatement(string id)
        {
            var treat = _treatement.GetTaxTreatement(id);
            if (treat != null)
            {
                _treatement.DeleteTaxTreatement(treat);
                return Ok();
            }
            return NotFound($"The Tax treatement with id {id} was not found");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EDitTreatement(string id, [FromBody] TaxTreatementTb treat)
        {
            var Existingtreat = _treatement.GetTaxTreatement(id);
            if (Existingtreat != null)
            {
                Existingtreat.ClassificationId = treat.ClassificationId;
                Existingtreat.TaxId = treat.TaxId;
                Existingtreat.StateId = treat.StateId;
                Existingtreat.TaxPercentage = treat.TaxPercentage;

                _treatement.EditTaxTreatement(Existingtreat);
                return Ok(treat);
            }
            return NotFound($"The category with id {id} was not found");
        }
    }
}
