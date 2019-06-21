using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BW.API.Model;
using BW.Application;
using BW.Application.UseCases.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductUseCase _productUseCase;

        public ProductController(
            IProductUseCase productUseCase
            )
        {
            _productUseCase = productUseCase;
        }

        [HttpGet("{sku}")]
        public async Task<IActionResult> Obter(int sku) {

            try
            {
                if (sku <= 0)
                {
                    return BadRequest("sku nao informado");
                }

                var product = await _productUseCase.Get(sku);

                return Ok(product);
            }
            catch (DomainException exb)
            {
                return BadRequest(exb.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost()]
        public async Task<IActionResult> Adicionar([FromBody] ProductRequest request)
        {
            try
            {
                var mapper = new MapperProduct();
                Domain.ProductDomain productDomain = mapper.MapperRequestToDomain(request);

                await _productUseCase.Add(productDomain);

                return Ok();
            }
            catch (DomainException exb)
            {
                return BadRequest(exb.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        [HttpPatch()]
        public async Task<IActionResult> Alterar([FromBody] ProductRequest request)
        {
            try
            {
                var mapper = new MapperProduct();
                Domain.ProductDomain productDomain = mapper.MapperRequestToDomain(request);

                await _productUseCase.Update(productDomain);

                return Ok();
            }
            catch (DomainException exb)
            {
                return BadRequest(exb.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete("sku")]
        public async Task<IActionResult> Deletar(int sku)
        {
            try
            {
                if (sku <= 0)
                {
                    return BadRequest("sku nao informado");
                }

                await _productUseCase.Delete(sku);

                return Ok();
            }
            catch (DomainException exb)
            {
                return BadRequest(exb.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}