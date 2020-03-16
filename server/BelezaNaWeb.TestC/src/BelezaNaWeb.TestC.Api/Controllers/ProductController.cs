using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BelezaNaWeb.TestC.Api.Data;
using BelezaNaWeb.TestC.Api.Exceptions;
using BelezaNaWeb.TestC.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelezaNaWeb.TestC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductDao _productDao;

        public ProductController(IProductDao productDao)
            => this._productDao = productDao;

        [HttpGet("{sku}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> Get(uint sku)
        {
            var product = _productDao.Get(sku);
            if (product == null)
                return NotFound(new { ErrorMessage = "Produto não encontrado" });

            return product;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product.IsValid())
            {
                try
                {
                    _productDao.Add(product);
                    return Ok();
                }
                catch (ObjetoJaExistenteNoBDException ex)
                {
                    return BadRequest(new { ErrorMessage = ex.Message });
                }
                catch
                {
                    return BadRequest(new { ErrorMessage = "Ocorreu um erro ao inserir um novo produto" });
                }
            }

            return BadRequest(new { ErrorMessage = "Produto inválido!" });
        }

        [HttpPut("{sku}")]
        public IActionResult Put(uint sku, [FromBody] Product product)
        {
            if (product.IsValid())
            {
                try
                {
                    _productDao.Edit(sku, product);
                    return Ok();
                }
                catch (ObjetoNaoEncontradoNoBDException ex)
                {
                    return BadRequest(new { ErrorMessage = ex.Message });
                }
                catch
                {
                    return BadRequest(new { ErrorMessage = "Ocorreu um erro ao editar o produto" });
                }
            }

            return BadRequest(new { ErrorMessage = "Produto inválido!" });
        }

        [HttpDelete("{sku}")]
        public IActionResult Delete(uint sku)
        {
            try
            {
                _productDao.Delete(sku);
                return Ok();
            }
            catch (ObjetoNaoEncontradoNoBDException ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
            catch
            {
                return BadRequest(new { ErrorMessage = "Ocorreu um erro ao excluir o produto" });
            }
        }
    }
}
