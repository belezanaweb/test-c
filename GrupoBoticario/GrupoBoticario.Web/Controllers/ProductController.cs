using GrupoBoticario.Application.Interfaces;
using GrupoBoticario.Domain.Payload.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MonitoreService.StatusServico.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IProductApplicationService _productApplicationService;

        public ProductController(
            ILogger<ProductController> logger,
            IProductApplicationService productApplicationService)
        {
            _logger = logger;
            _productApplicationService = productApplicationService;
        }

        [HttpPost]
        [Route("save-product")]
        public async Task<IActionResult> SaveProduct(IEnumerable<ProductSavePayload> payloads)
        {           
            try
            {
                if (ModelState.IsValid is false)
                {
                    return BadRequest(ModelState);
                }

                _logger.LogInformation($"Inserindo a entidade {nameof(payloads)}.");

                await _productApplicationService.AddProduct(payloads);

                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }           
        }

        [HttpPut]
        [Route("edit-product")]
        public async Task<IActionResult> EditProduct(IEnumerable<ProductUpdatePayload> payloads)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    return BadRequest(ModelState);
                }

                _logger.LogInformation($"Atualizando a entidade {nameof(payloads)}.");

                await _productApplicationService.UpdateProduct(payloads);

                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("delete-product/{sku}")]
        public async Task<IActionResult> DeleteProduct(long sku)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    return BadRequest(ModelState);
                }

                _logger.LogInformation($"Excluindo pelo {nameof(sku)}.");

                await _productApplicationService.DeleteProduct(sku);

                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("search-product/{sku}")]
        public async Task<IActionResult> SearchProduct(long sku)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    return BadRequest(ModelState);
                }

                _logger.LogInformation($"Excluindo pelo {nameof(sku)}.");

                var retorno =  await _productApplicationService.ObterPorId(sku);

                return Ok(retorno);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("search-all-product")]
        public async Task<IActionResult> SearchAllProduct()
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    return BadRequest(ModelState);
                }               

                var retorno = await _productApplicationService.ObterTodos();

                return Ok(retorno);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
