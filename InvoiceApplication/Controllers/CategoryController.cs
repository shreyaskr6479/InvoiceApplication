using InvoiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using InvoiceApplication.Container;
using InvoiceApplication.DTOs;

namespace InvoiceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryContainer _categoryContainer;

        public CategoryController(ICategoryContainer categoryContainer)
        {
            this._categoryContainer = categoryContainer;
        }

        // GET: api/Category/GetAllCategories
        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            try
            {
                var categories = await this._categoryContainer.GetCategories();

                return Ok(categories);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            try
            {
                var category = await _categoryContainer.GetCategoryByCategoryId(id);

                if (category == null)
                {
                    return NotFound();
                }
                return category;
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            try
            {
                if (id != category.Id)
                {
                    return BadRequest();
                }

                if (_categoryContainer.IsCategoryExists(id))
                {
                    await _categoryContainer.UpdateCategory(category);
                }
                else
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            try
            {
                await _categoryContainer.AddCategory(category);
                return CreatedAtAction("GetCategory", new { id = category.Id }, category);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _categoryContainer.GetCategoryToDeleteByCategoryId(id);

                if (category == null)
                {
                    return NotFound();
                }

                await _categoryContainer.DeleteCategory(category);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}