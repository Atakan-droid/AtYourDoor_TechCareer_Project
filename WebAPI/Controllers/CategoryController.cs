using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize(Roles="Admin")]
        [HttpPost("addcategory")]
        public IActionResult AddCategory(Category category)
        {
            var result = _categoryService.AddCategory(category);
            if (result.Success)
            {
                return Created(nameof(CategoryController.AddCategory), result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("deletecategory/{id:int}")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("harddeletecategory/{id:int}")]
        public IActionResult HardDeleteCategory(int id)
        {
            var result = _categoryService.HardDeleteCategory(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updatecategory/{id:int}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            var result = _categoryService.UpdateCategory(id, category);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcategory/{id:int}")]
        public IActionResult GetCategory(int id)
        {
            var result = _categoryService.GetCategoryById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcategories")]
        public IActionResult GetCategories()
        {
            var result = _categoryService.GetCategories();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
