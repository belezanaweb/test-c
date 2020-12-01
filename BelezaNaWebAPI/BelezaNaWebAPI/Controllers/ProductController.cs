using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace BelezaNaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static IProductRepository _repository = new ProductRepository();
        public ProductController()
        {

        }

        [HttpGet]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ProductModel), 200)]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), 200)]
        public IActionResult Get([FromQuery] long? sku)
        {
            try
            {
                if (sku.HasValue)
                {
                    return Ok(_repository.GetBySku(sku.Value));
                }
                else
                {
                    return Ok(_repository.GetAll());
                }

            }
            catch (ProductException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(ProductModel), 200)]
        public IActionResult Create(ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Model is invalid" });
            }

            try
            {
                _repository.Create(product);
                return Ok(_repository.GetBySku(product.Sku));
            }
            catch (ProductException e)
            {
                return BadRequest(new { message = e.Message });
            }

        }

        [HttpPut("{sku}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ProductModel), 200)]
        public IActionResult Update([FromRoute] long sku, ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Model is invalid" });
            }

            try
            {
                _repository.Update(sku, product);
                return Ok(_repository.GetBySku(product.Sku));
            }
            catch (ProductException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpDelete("{sku}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public IActionResult Delete([FromRoute] long sku)
        {
            try
            {
                _repository.Delete(sku);
                return NoContent();
            }
            catch (ProductException e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
