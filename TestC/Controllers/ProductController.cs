using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TestC.Models;
using TestC.Services;

namespace TestC.Controllers
{
    [ApiController, ExcludeFromCodeCoverageAttribute]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService service, ILogger<ProductController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            _logger.LogInformation("Posting product");
            return Ok(_service.Insert(product));
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            _logger.LogInformation("Updating product");
            return Ok(_service.Update(product));
        }

        [HttpDelete, Route("{sku}")]
        public IActionResult Delete(int sku)
        {
            _logger.LogInformation("Deleting product");
            _service.Delete(sku);
            return NoContent();
        }

        [HttpGet, Route("{sku}")]
        public IActionResult Get(int sku)
        {
            var product = _service.GetByID(sku);
            return Ok(product);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        


    }
}