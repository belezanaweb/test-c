using Boticario.Application.InputModels;
using Boticario.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Boticario.API.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }        

        [HttpPost]
        public IActionResult Post([FromBody] NewProductInputModel inputModel)
        {
            var sku = _productService.Create(inputModel);

            return CreatedAtAction(nameof(GetBySku), new { sku = sku }, inputModel);
        }

        [HttpGet("{sku}")]
        public IActionResult GetBySku(int sku)
        {
            var product = _productService.GetBySku(sku);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPut("{sku}")]
        public IActionResult Put(int sku, [FromBody] UpdateProductInputModel inputModel)
        {
            _productService.Update(inputModel);

            return NoContent();
        }        

        [HttpDelete("{sku}")]
        public IActionResult Delete(int sku)
        {
            _productService.Delete(sku);

            return NoContent();
        }
    }
}
