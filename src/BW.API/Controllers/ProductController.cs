using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BW.AplicationCore.Entities;
using BW.AplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace BW.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await Task.FromResult(_productService.GetAll());

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var product = await Task.FromResult(_productService.Get(id));

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            try
            {
                await Task.Run(() => _productService.Add(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }   

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Product product)
        {
            try
            {
                await Task.Run(()=>_productService.Update(product));
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message) ;
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await Task.Run(() => _productService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
