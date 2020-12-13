using Desafio.Application.Interfaces;
using Desafio.Application.ViewModels.CreateUpdate;
using Desafio.Application.ViewModels.Read;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/<ProductController>/5
        [HttpGet("{sku}")]
        public IActionResult Get(int sku)
        {
            var result = _productService.Read(sku);
            if (result == null)
                return NoContent();
            else
                return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductCreateUpdateReadViewModel product)
        {
            return Response(_productService.Create(product));
        }

        // PUT api/<ProductController>/5
        [HttpPut()]
        public IActionResult Put([FromBody] ProductCreateUpdateReadViewModel product)
        {
            return Response(_productService.Update(product));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{sku}")]
        public IActionResult Delete(int sku)
        {
            return Response(_productService.Delete(sku));
        }
    }
}
