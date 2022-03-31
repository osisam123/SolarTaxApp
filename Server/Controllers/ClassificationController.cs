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
    public class ClassificationController : ControllerBase
    {
        private readonly ILogger<ClassificationController> logger;
        private IClassificationData _classification;
        private IClassificationListData _classificationList;
        public ClassificationController(ILogger<ClassificationController> logger, IClassificationData classification, IClassificationListData classificationList)
        {
            this.logger = logger;
            this._classification = classification;
            this._classificationList = classificationList;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetClassification()
        {
            return Ok(_classificationList.GetActualClassification());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetClassification(string id)
        {
            var classification = _classificationList.GetActualClassification(id);
            if (classification != null)
                return Ok(classification);
            else
                return NotFound($"The classification with id {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddClassification(ClassificationTb classification)
        {
            _classification.AddClassification(classification);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + classification.ClassificationId, classification);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteClassification(string id)
        {
            var classification = _classification.GetClassification(id);
            if (classification != null)
            {
                _classification.DeleteClassification(classification);
                return Ok();
            }
            return NotFound($"The classification with id {id} was not found");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EDitCategory(string id, [FromBody] ClassificationTb classification)
        {
            var Existingclassification = _classification.GetClassification(id);
            if (Existingclassification != null)
            {
                Existingclassification.CategoryId = classification.CategoryId;
                Existingclassification.SolarModularCapacity = classification.SolarModularCapacity;
                Existingclassification.Description = classification.Description;
                Existingclassification.IllustrationUrl = classification.IllustrationUrl;
                Existingclassification.HsCode = classification.HsCode;

                _classification.EditClassification(Existingclassification);
                return Ok(classification);
            }
            return NotFound($"The classification with id {id} was not found");
        }
    }
}
