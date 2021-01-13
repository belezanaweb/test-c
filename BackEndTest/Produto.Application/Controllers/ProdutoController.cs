using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Produto.Domain.DTO;
using Produto.Domain.Models;
using Produto.Domain.Services;
using System.Text.Json.Serialization;
using System.Text.Json;


namespace Produto.Application.Controllers
{
    /// <summary>
    /// Api de Produtos para implementacao do BackEndTest
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProdutoController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retorna informacoes sobre API
        /// </summary>
        /// <returns></returns>
        [HttpGet("About")]
        public ContentResult About()
        {
            return Content("Api created by Ana Paula de Souza for testing in Grupo Boticario. V1");
        }


        /// <summary>
        /// Recupera um produto por sku
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        /// <response code="200">Retorna o produto com o sku informado</response>
        /// <response code="400">Quando o produto não é encontrado</response>
        [HttpGet("{(sku)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string sku)
        {
            try
            {
                var product = productService.FindBy(sku);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Insere um novo produto de acordo com o payload de produto
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns></returns>
        /// <response code="201">Produto cadastrado sem erros</response>
        /// <response code="400">Erro para cadastrar o produto</response>
        [HttpPost("Include")]
        public ActionResult<ProductDTO> Include([FromBody] ProductDTO productDTO)
        {     
            //var productDTO = JsonSerializer.Deserialize<ProductDTO>(parameterProduct);

            try
            {

                var product = mapper.Map<Product>(productDTO);
                var ok = productService.AddAsync(product);

                return Created($"/api/produtos/{product?.Id}", product?.Sku);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        /// <summary>
        /// Atualiza um produto de acordo com o payload de produto
        /// </summary>
        /// <param name="parameterProduct"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="201">Produto atualizado sem erros</response>
        /// <response code="400">Erro para atualizar o produto</response>
        [HttpPost("Update")]
        public ActionResult<ProductDTO> Update(int id, string parameterProduct)
        {
            var productDTO = JsonSerializer.Deserialize<ProductDTO>(parameterProduct);

            try
            {

                var product = mapper.Map<Product>(productDTO);
                var ok = productService.Update(id, product);

                return Created($"/api/produtos/{product?.Id}", product?.Sku);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Excluir um produto por sku
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        /// <response code="200">Produto removido sem erros</response>
        /// <response code="400">Erro para remover o produto</response>
        [HttpPost("Delete")]
        public ActionResult<ProductDTO> Delete(string sku)
        {

            try
            {
                productService.Remove(sku);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}