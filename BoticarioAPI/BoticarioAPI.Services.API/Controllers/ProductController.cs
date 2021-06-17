using BoticarioAPI.Domain.Interfaces.Application;
using BoticarioAPI.Domain.TransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            if (_productApp.Add(product))
                return Ok();
            else
                return StatusCode((int)HttpStatusCode.Conflict, new { Message = "Produto com mesmo SKU já cadastrado" });
        }

        [HttpPut]
        public IActionResult Update([FromBody] NewProductTO product)
        {
            if (_productApp.Update(product))
                return Ok();
            else
                return StatusCode((int)HttpStatusCode.NotFound, new { Message = "Produto não encontrado" });

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_productApp.Delete(id));
        }

        [HttpGet("{sku}")]
        public IActionResult Get(int sku)
        {
            var product = _productApp.Get(sku);
            if(product != null)
                return Ok(product);
            else
                return StatusCode((int)HttpStatusCode.NotFound, new { Message = "Produto não encontrado" });
        }
    }
}
