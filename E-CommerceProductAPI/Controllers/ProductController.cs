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

        public ProductController(IProductService productService)
        {
            _productService = productService;
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
            var product = await _productService.GetProductByIdAsync(id, cancellationToken);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("GetProductCategories/{id}")]
        public async Task<ActionResult<IEnumerable<ProductResponseModel>>> GetProductCategories(Guid id,CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetProductCategoriesAsync(id,cancellationToken));
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
    }
}
