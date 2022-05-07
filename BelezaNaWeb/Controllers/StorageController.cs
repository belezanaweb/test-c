using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BelezaNaWeb.Entities;
using BelezaNaWeb.Services;

namespace BelezaNaWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {

        [HttpGet("sku/{sku}")]
        public IActionResult Get(long sku)
        {
            try
            {
                return Ok(StorageControl.GetProduct(sku));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                StorageControl.AddProduct(product);
                return Ok("Produto salvo com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("sku/{sku}")]
        public IActionResult Put(long sku, [FromBody] ProductDTO product)
        {
            try
            {
                StorageControl.UpdateProduct(sku, product);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
