using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testc.Business;
using testc.Model;

namespace test_c.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductBusiness _productBusiness;

        public ProductsController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        // GET api/products
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productBusiness.GetAll());
        }

        // GET api/products/5
        [HttpGet("{sku}")]
        public IActionResult Get(int sku)
        {
            var product = _productBusiness.GetBySku(sku);
            if (product == null) return NotFound();
            return Ok(product);

        }

        // POST api/products
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null) return BadRequest();
            return new ObjectResult(_productBusiness.Create(product));
        }

        // PUT api/products/5
        [HttpPut("{sku}")]
        public IActionResult Put([FromBody] Product product)
        {
            if (product == null) return BadRequest();
            var updatedProduct = _productBusiness.Update(product);
            if (updatedProduct == null) return BadRequest();
            return new ObjectResult(_productBusiness.Update(product));
        }

        // DELETE api/products/5
        [HttpDelete("{sku}")]
        public IActionResult Delete(int sku)
        {
            _productBusiness.Delete(sku);
            return NoContent();
        }
    }
}
