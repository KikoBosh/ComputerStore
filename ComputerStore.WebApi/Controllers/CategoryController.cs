using ComputerStore.Services.DTOs;
using ComputerStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryDTO category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            var addedCategory = _categoryService.AddCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = addedCategory.Id }, addedCategory);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryDTO category)
        {
            if (category == null || id != category.Id)
            {
                return BadRequest();
            }

            var existingCategory = _categoryService.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            var updatedCategory = _categoryService.UpdateCategory(category);
            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var existingCategory = _categoryService.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            var deleted = _categoryService.DeleteCategory(id);
            if (deleted)
            {
                return NoContent();
            }
            else
            {
                throw new Exception("Failed to delete category.");
            }
        }
    }

}

