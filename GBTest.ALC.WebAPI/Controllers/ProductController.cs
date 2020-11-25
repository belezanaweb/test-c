using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
//using Microsoft.Extensions.Logging;

namespace GBTest.ALC.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        //private readonly ILogger<ProductController> _logger;
        private Domain.Interfaces.IProductService _productService;

        //ILogger<ProductController> logger
        public ProductController(Domain.Interfaces.IProductService productService)
        {
            //_logger = logger;
            _productService = productService;
        }

        [HttpPost]
        public void Post([FromBody()] Domain.Entities.Product product)
        {
            _productService.Add(product);
        }

        [HttpPost]
        public void Update([FromBody()] Domain.Entities.Product product)
        {
            _productService.Update(product);
        }

        [HttpPost]
        public void Delete([FromBody()] Domain.Entities.Product product)
        {
            _productService.Remove(product);
        }

        [HttpGet("{sku}")]
        public Domain.Entities.Product Get(string sku)
        {
            return _productService.Get(sku);
        }

        [HttpGet()]
        public List<Domain.Entities.Product> Get()
        {
            var items = _productService.GetAll();
            if (items != null && items.Count > 0)
                return items;
            return null;
        }
    }
}
