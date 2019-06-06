using Domain.Dtos;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet("/{sku}")]
        public ActionResult<ProductListDto> Get(long sku)
        {
            var product = _productAppService.GetById(sku);

            if (product == null)
                return NotFound();

            return product;
        }

        [HttpPost("/")]
        public ActionResult<ProductCreateDto> Post(ProductCreateDto product)
        {
            product.Sku = _productAppService.Register(product);

            return CreatedAtAction("Get", new { sku = product.Sku }, product);
        }

        [HttpPut("/{sku}")]
        public ActionResult<ProductUpdateDto> Put(long sku, ProductUpdateDto product)
        {
            if (sku != product.Sku)
                return BadRequest();
            try
            {
                product.Sku = _productAppService.Update(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ProductExists(sku))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("/{sku}")]
        public ActionResult<ProductListDto> Delete(long sku)
        {
            var product = _productAppService.GetById(sku);
            if (product == null)
                return NotFound();

            _productAppService.Remove(product.Sku);
            return NoContent();
        }

        private bool ProductExists(long sku)
        {
            return _productAppService.GetById(sku) != null;
        }
    }
}