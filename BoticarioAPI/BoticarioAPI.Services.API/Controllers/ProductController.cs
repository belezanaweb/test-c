using BoticarioAPI.Domain.Interfaces.Application;
using BoticarioAPI.Domain.TransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoticarioAPI.Services.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductApp _productApp;

        public ProductController(IProductApp productApp)
        {
            _productApp = productApp;
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewProductTO product)
        {
            return Ok(_productApp.Add(product));
        }

        [HttpPut]
        public IActionResult Update([FromBody] NewProductTO product)
        {
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        [HttpGet("{sku}")]
        public IActionResult Get(int sku)
        {
            return Ok(_productApp.Get(sku));
        }
    }
}
