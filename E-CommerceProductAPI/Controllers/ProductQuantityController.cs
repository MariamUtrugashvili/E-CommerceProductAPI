using E_CommerceProduct.Application.ProductQuantities.Request;
using E_CommerceProduct.Application.ProductQuantities.Response;
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

        [HttpGet("GetProductQuantities")]
        public async Task<ActionResult<IEnumerable<ProductQuantitiesResponseModel>>> GetProductQuantity(CancellationToken cancellationToken)
        {
            var productQuantity = await _productQuantityService.GetProductQuantity(cancellationToken);
            return Ok(productQuantity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductQuantity(Guid id, ProductQuantitiesPutModel productQuantity, CancellationToken cancellationToken)
        {
            await _productQuantityService.UpdateProductQuantityAsync(productQuantity, id, cancellationToken);
            return NoContent();
        }

    }
}

