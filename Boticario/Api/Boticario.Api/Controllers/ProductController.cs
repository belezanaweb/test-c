using Microsoft.AspNetCore.Mvc;
using Boticario.Domain.Entities;
using Boticario.Domain.Interfaces.Services;

namespace Boticario.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet("{sku}")]
        public ActionResult Get(int sku)
        {
            var product = _productService.GetProductBySku(sku);

            if (product != null)
                return Ok(product);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product model)
        {
            var product = _productService.Add(model);
            return Ok(product);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Product model)
        {
            var product = _productService.Update(model);

            if (product != null)
                return Ok(product);

            return NoContent();
        }

        [HttpDelete("{sku}")]
        public ActionResult Delete(int sku)
        {
            var deleted = _productService.Delete(sku);

            if (!deleted)
                return BadRequest();

            return NoContent();
        }
    }
}