using E_CommerceProduct.Application.Categories.Request;
using E_CommerceProduct.Application.Categories.Response;
using E_CommerceProduct.Application.Services;
using E_CommerceProduct.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponseModel>>> GetCategories(CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.GetAllCategoriesAsync(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseModel>> GetCategory(Guid id, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id, cancellationToken);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CategoryRequestModel category, CancellationToken cancellationToken)
        {
            await _categoryService.CreateCategoryAsync(category, cancellationToken);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryRequestModel category, CancellationToken cancellationToken)
        {
 
            await _categoryService.UpdateCategoryAsync(category, id, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken)
        {
            await _categoryService.DeleteCategoryAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
