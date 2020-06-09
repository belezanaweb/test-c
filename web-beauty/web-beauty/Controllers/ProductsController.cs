using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_beauty.Data;
using web_beauty.Models;
using web_beauty.Repositories;
using web_beauty.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_beauty.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ProductService _productService;
        public ProductsController()
        {
            var context = new Context("27017", "localhost");
            var repo = new ProductRepository(context);
            _productService = new ProductService(repo);
        }

        // POST api/products/post
        [HttpPost]
        public async Task Post([FromBody] Product product)
        {
           await _productService.CreateProduct(product);
        }

        // POST api/products/delete
        [HttpPost]        
        public async Task Delete([FromQuery] long sku)
        {
            await _productService.Delete(sku);
        }

        // POST api/products/GetBySku?sku={sku}
        [HttpGet]
        public async Task<Product> GetBySku([FromQuery] long sku)
        {
            return await _productService.GetBySku(sku);
        }

        // POST api/products/post
        [HttpPost]
        public async Task Update([FromBody] Product product)
        {
            await _productService.Update(product);
        }
    }
}
