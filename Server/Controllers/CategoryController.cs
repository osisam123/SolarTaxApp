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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> logger;
        private ICategoryData _category;
        public CategoryController(ILogger<CategoryController> logger, ICategoryData category)
        {
            this.logger = logger;
            this._category = category;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetCategory()
        {
            return Ok(_category.GetCategory());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetCategory(string id)
        {
            var category = _category.GetCategory(id);
            if (category != null)
                return Ok(category);
            else
                return NotFound($"The category with id {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddCategory(CategoryTb category)
        {
            _category.AddCategory(category);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + category.Categoryid, category);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteCategory(string id)
        {
            var category = _category.GetCategory(id);
            if (category != null)
            {
                _category.DeleteCategory(category);
                return Ok();
            }
            return NotFound($"The category with id {id} was not found");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EDitCategory(string id, [FromBody] CategoryTb category)
        {
            var Existingcategory = _category.GetCategory(id);
            if (Existingcategory != null)
            {
                Existingcategory.Categoryname = category.Categoryname;
                Existingcategory.CategoryDescription = category.CategoryDescription;
                Existingcategory.Imageurl = category.Imageurl;
                
                _category.EditCategory(Existingcategory);
                return Ok(category);
            }
            return NotFound($"The category with id {id} was not found");
        }
    }
}
