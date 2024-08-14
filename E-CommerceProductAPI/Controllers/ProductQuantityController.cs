using E_CommerceProduct.Application.Services;
using E_CommerceProduct.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductQuantityController : ControllerBase
    {
        private readonly IProductQuantityService _productQuantityService;

        public ProductQuantityController(IProductQuantityService productQuantityService)
        {
            _productQuantityService = productQuantityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductQuantity>>> GetProductQuantities(CancellationToken cancellationToken)
        {
            return Ok(await _productQuantityService.GetAllProductQuantitiesAsync(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductQuantity>> GetProductQuantity(Guid id, CancellationToken cancellationToken)
        {
            var productQuantity = await _productQuantityService.GetProductQuantityByIdAsync(id, cancellationToken);
            if (productQuantity == null)
                return NotFound();
            return Ok(productQuantity);
        }

        [HttpPost]
        public async Task<ActionResult<ProductQuantity>> CreateProductQuantity(ProductQuantity productQuantity, CancellationToken cancellationToken)
        {
            var createdProductQuantity = await _productQuantityService.CreateProductQuantityAsync(productQuantity, cancellationToken);
            return CreatedAtAction(nameof(GetProductQuantity), new { id = createdProductQuantity.Id }, createdProductQuantity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductQuantity(Guid id, ProductQuantity productQuantity, CancellationToken cancellationToken)
        {
            if (id != productQuantity.Id)
                return BadRequest();

            await _productQuantityService.UpdateProductQuantityAsync(productQuantity, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductQuantity(Guid id, CancellationToken cancellationToken)
        {
            await _productQuantityService.DeleteProductQuantityAsync(id, cancellationToken);
            return NoContent();
        }
    }
}

