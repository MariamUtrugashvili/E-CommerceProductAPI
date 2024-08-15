using E_CommerceProduct.Application.ProductCategories.Request;
using E_CommerceProduct.Application.Products.Request;
using E_CommerceProduct.Application.Products.Response;
using E_CommerceProduct.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<ProductResponseModel>>> GetProductCategories(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _productCategoryService.GetProductCategoriesAsync(id, cancellationToken));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProductCategory(UpdateProductCategoryRequest request, Guid id, CancellationToken cancellationToken)
        {
            await _productCategoryService.UpdateProductCategoryAsync(request, id, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProductCategory(Guid id, CancellationToken cancellationToken)
        {
            await _productCategoryService.DeleteProductCategoryAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
