using BelezaNaWeb.Core.Model;
using BelezaNaWeb.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BelezaNaWeb.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet("{sku}")]
        public ActionResult Get(int sku)
        {
            var productBySku = _productServices.GetProductBySku(sku);

            return productBySku != null ? (ActionResult) Ok(productBySku) : NoContent();
        }

        [HttpPost]
        public ActionResult<Product> GetById([FromBody] Product product)
        {
            var newProduct = _productServices.Add(product);
            return Ok(newProduct);
        }

        [HttpDelete("{sku}")]
        public ActionResult Delete(int sku)
        {
            var deleted = _productServices.Delete(sku);

            if (!deleted)
                return BadRequest();

            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Product product)
        {
            var productUpdate = _productServices.Update(product);
            return productUpdate != null ? (ActionResult)Ok(productUpdate) : NoContent();
        }
    }
}
