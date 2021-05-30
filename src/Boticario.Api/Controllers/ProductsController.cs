using AutoMapper;
using Boticario.ApplicationService.IServices;
using Boticario.ApplicationService.Services;
using Boticario.Domain.Handlers;
using Boticario.Domain.Models;
using Boticario.Domain.Search;
using Boticario.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Boticario.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    //[ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : MainController
    {
       
        private readonly IProductsService _productsService;


        public ProductsController(IProductsService productsService,  ILogger<ProductsController> logger,  INotification notification) : base(logger, notification)
        {
            _productsService = productsService;
        }


        /// <summary>
        /// LISTA TODOS OS PRODUTOS
        /// </summary>
        /// <returns>Products</returns>  
        [ProducesResponseType(typeof(List<Products>), 200)]
        [HttpGet]
        [ApiVersion("1.0")]
        [ApiVersion("2.0")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productsService.Get();

                return Result(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        /// <summary>
        /// ESTE ENPOINT RETORNA PRODUTOS DE ACORDO O FILTRO NA QUERYSTRING
        /// </summary>
        /// <returns>Products</returns>  
        [ProducesResponseType(typeof(List<Products>), 200)]
        [HttpGet("Search")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Search([FromQuery] ProductSearch filterQuery)
        {
            try
            {

                var product = await _productsService.Search(filterQuery);

                return Result(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        /// <summary>
        /// RETORNA UM PRODUTO DE DE ACORDO O SKU PASADO NA URL
        /// </summary>     
        /// <returns></returns>
        [ProducesResponseType(typeof(Products), 200)]
        [HttpGet("{sku:int}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Get(int sku)
        {
            try
            {

                var product = await _productsService.Get(sku);

                return Result(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        /// <summary>
        /// METODO PARA INSERIR PRODUTO
        /// </summary>            
        /// <returns></returns>
        [ApiVersion("1.0")]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.Created)]
        [HttpPost]
        public async Task<IActionResult> Save(ProductViewModel product)
        {
            try
            {

                var productSaved = await _productsService.Save(product);

                //return ResultPost("Produto salvo com sucesso!");

                return Result(productSaved);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// METODO PARA EDITAR PRODUTOS
        /// </summary>     
        /// <returns></returns>
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        [HttpPut("{sku:int}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Update(int sku, ProductUpdateViewModel product)
        {
            try
            {
                var productUpdated = await _productsService.Update(sku, product);

                return Result(productUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }



        /// <summary>
        /// METODO PARA EXCLUIR UM PRODUTO PELO SKU
        /// </summary>     
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [HttpDelete("{sku:int}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Delete(int sku)
        {
            try
            {
                var productUpdated = await _productsService.Delete(sku);

                return Result(productUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


    }
}
