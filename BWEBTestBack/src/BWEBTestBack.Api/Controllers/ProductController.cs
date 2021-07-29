using BWEBTestBack.Business.Interfaces;
using BWEBTestBack.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BWEBTestBack.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpGet("{sku:int}")]
        public async Task<ActionResult<Product>> Get(int sku)
        {
            var product = await _productService.Get(sku);

            var options = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = new JsonResult(product, options);

            return json;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Add(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _productService.Add(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Product>> Update(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _productService.Update(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{sku:int}")]
        public async Task<ActionResult<Product>> Delete(int sku)
        {
            try
            {
                await _productService.Delete(sku);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

    }
}
