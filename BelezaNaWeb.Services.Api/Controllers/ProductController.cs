using BelezaNaWeb.Application.Interfaces;
using BelezaNaWeb.Application.ViewModels;
using BelezaNaWeb.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BelezaNaWeb.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService productAppService;

        public ProductController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        [HttpGet("{sku}")]
        public IActionResult GetBySku(int sku)
        {
            try
            {
                var product = productAppService.GetBySku(sku);
                return Ok(product);
            }
            catch(DomainException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductViewModel product)
        {
            try
            {
                productAppService.Register(product);
                return Ok(product);
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut()]
        public IActionResult Put([FromBody] ProductViewModel product)
        {
            try
            {
                productAppService.Update(product);
                return Ok(product);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("sku")]
        public IActionResult Delete(int sku)
        {
            try
            {
                productAppService.Remove(sku);
                return Ok($"Product {sku} successfully removed.");
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}