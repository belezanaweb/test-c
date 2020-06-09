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
    [Route("api/products")]
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

        // POST api/<ProductsController>
        [HttpPost]
        public async Task Post([FromBody] Product product)
        {
           await _productService.CreateProduct(product);
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<string> Get([FromServices] Context context)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
