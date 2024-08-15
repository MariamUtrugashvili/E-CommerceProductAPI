using E_CommerceProduct.Application.ProductCategories.Request;
using E_CommerceProduct.Application.Products.Request;
using E_CommerceProduct.Application.Products.Response;
using E_CommerceProduct.Application.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerable<ProductResponseModel>>> GetProducts(CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetAllProductsAsync(cancellationToken));
        }

        [HttpGet("ProductDetails")]
        public async Task<ActionResult<IEnumerable<ProductResponseModel>>> GetProductDetails(CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetProductDetailsAsync(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseModel>> GetProduct(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetProductByIdAsync(id, cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductRequestModel product, CancellationToken cancellationToken)
        {
            await _productService.CreateProductAsync(product, cancellationToken);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, UpdateProductRequestModel product, CancellationToken cancellationToken)
        {

            await _productService.UpdateProductAsync(product, id, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
