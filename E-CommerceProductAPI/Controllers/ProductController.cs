using E_CommerceProduct.Application.ProductCategories.Request;
using E_CommerceProduct.Application.Products.Request;
using E_CommerceProduct.Application.Products.Response;
using E_CommerceProduct.Application.Services;
using E_CommerceProduct.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace E_CommerceProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductResponseModel>>> GetProducts(CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetAllProductsAsync(cancellationToken));
        }

        [HttpGet("ProductDetails")]
        public async Task<ActionResult<IEnumerable<ProductResponseModel>>> GetProductDetails(CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetProductDetailsAsync(cancellationToken));
        }

        [HttpGet("GetProduct{id}")]
        public async Task<ActionResult<ProductResponseModel>> GetProduct(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetProductByIdAsync(id, cancellationToken));
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult> CreateProduct(CreateProductRequestModel product, CancellationToken cancellationToken)
        {
            await _productService.CreateProductAsync(product, cancellationToken);
            return Created();
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, UpdateProductRequestModel product, CancellationToken cancellationToken)
        {

            await _productService.UpdateProductAsync(product, id, cancellationToken);
            return NoContent();
        }

        [HttpDelete("DeleteProduct{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductAsync(id, cancellationToken);
            return NoContent();
        }

        [HttpGet("GetProductCategories/{id}")]
        public async Task<ActionResult<IEnumerable<ProductResponseModel>>> GetProductCategories(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _productCategoryService.GetProductCategoriesAsync(id, cancellationToken));
        }

        [HttpPut("UpdateProductCategory{id:guid}")]
        public async Task<IActionResult> UpdateProductCategory(UpdateProductCategoryRequest request, Guid id, CancellationToken cancellationToken)
        {
            await _productCategoryService.UpdateProductCategoryAsync(request, id, cancellationToken);
            return NoContent();
        }

        [HttpDelete("DeleteProductCategory/{id:guid}")]
        public async Task<IActionResult> DeleteProductCategory(Guid id, CancellationToken cancellationToken)
        {
            await _productCategoryService.DeleteProductCategoryAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
