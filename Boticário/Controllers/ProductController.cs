using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productBusiness.GetAll();

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBySku(int id)
        {
            try
            {
                return Ok(await _productBusiness.GetBySKU(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            try
            {
                return Ok(await _productBusiness.Add(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(int id, ProductViewModel model)
        {
            try
            {
                return Ok(await _productBusiness.Update(model));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productBusiness.Remove(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
