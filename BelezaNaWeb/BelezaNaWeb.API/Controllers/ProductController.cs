using BelezaNaWeb.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BelezaNaWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _productContext;

        public ProductController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        /// <summary>
        /// Get a specific product
        /// </summary>
        /// <param name="sku"></param>   
        [HttpGet("{sku}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> Get(int sku)
        {
            var product = _productContext.Products.FirstOrDefault(x => x.Sku == sku);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Create a specific product
        /// </summary>
        /// <param name="item"></param>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> Create(Product item)
        {
            var product = _productContext.Products.FirstOrDefault(x => x.Sku == item.Sku);

            if (product != null)
            {
                return BadRequest("Dois produtos são considerados iguais se os seus skus forem iguais");
            }

            _productContext.Products.Add(item);

            return CreatedAtRoute("", new { sku = item.Sku }, item);
        }

        /// <summary>
        /// Edit a specific product
        /// </summary>
        /// <param name="sku"></param>   
        /// <param name="item"></param>   
        [HttpPut("{sku}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> Edit(int sku, Product item)
        {
            var product = _productContext.Products.FirstOrDefault(x => x.Sku == sku);

            if (product == null)
            {
                return NotFound();
            }

            product = item;

            return Ok(product);
        }

        /// <summary>
        /// Deletes a specific product
        /// </summary>
        /// <param name="sku"></param>   
        [HttpDelete("{sku}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int sku)
        {
            var product = _productContext.Products.FirstOrDefault(x => x.Sku == sku);

            if (product == null)
            {
                return NotFound();
            }

            _productContext.Products.Remove(product);

            return Ok();
        }
    }
}
