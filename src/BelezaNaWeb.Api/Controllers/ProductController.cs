using BelezaNaWeb.Domain.Model;
using BelezaNaWeb.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BelezaNaWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _repository;

        public ProductController(ILogger<ProductController> logger, IProductRepository repository)
        {
            _logger = logger;
            this._repository = repository;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetAsync()
        {
            return await Task.Run(() =>
            {
                var products = _repository.List();

                return Ok(products);
            });
        }


        [HttpGet("{sku}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetBySkuAsync(int sku)
        {
            var product = await Task.Run(() => _repository.Get(sku));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> PostAsync([FromBody] Product value)
        {
            return await Task.Run(() =>
            {
                return Ok(_repository.Add(value));
            });
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PutAsync(int sku, [FromBody] Product value)
        {
            return await Task.Run(() =>
            {
                return Ok(_repository.Update(value));
            });
        }

        // DELETE api/values/5
        [HttpDelete("{sku}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task DeleteAsync(int sku)
        {
            await Task.Run(() =>
            {
                _repository.Delete(sku);
            });
        }
    }
}