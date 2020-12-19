using System.Collections.Generic;
using System.Threading.Tasks;
using Boticario.Test.Application.Entity;
using Boticario.Test.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Boticario.Test.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IService<Product> _service;

        public ProductController(IService<Product> service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(Product product)
        {
            return Created("", await _service.add(product));
        }

        [HttpPut]
        [Route("sku/{sku}")]
        public async Task<IActionResult> Put(int sku, [FromBody]Product product)
        {
            product.Sku = sku;
            await _service.update(product);
            return Ok();
        }

        [HttpDelete]
        [Route("sku/{sku}")]
        public async Task<IActionResult> Delete(int sku)
        {
            await _service.remove(sku);
            return NoContent();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.getAll());
        }

        [HttpGet]
        [Route("sku/{sku}")]
        public async Task<IActionResult> Get(int sku)
        {
            var product = await _service.getBySku(sku);

            if(product == null)
                return NotFound();

            return Ok(product);
        }
    }
}