using System;
using System.Collections.Generic;
using BelezaNaWeb.Api.Model;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Infra.CrossCutting;
using BelezaNaWeb.Domain.Entities;

namespace BelezaNaWeb.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        #region Attributes
        private static IMapper iMapper;
        private readonly IProductApplication _iProductApplication;
        #endregion

        #region Constructors
        public ProductController(IProductApplication iProductApplication)
        {
            _iProductApplication = iProductApplication;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductModel, Product>();
                cfg.CreateMap<InventoryModel, Inventory>();
                cfg.CreateMap<WarehouseModel, Warehouse>();
            });

            iMapper = config.CreateMapper();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Method that returns all products from the database
        /// </summary>
        /// <returns>List of products</returns>
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            try
            {
                var products = _iProductApplication.GetAll();

                return Ok(products);
            }
            catch (Exception ex)
            {
                SimpleLog.Error($"Error message: {ex.Message}. Inner exception: {ex.InnerException}!");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method that gets the product by your sku code
        /// </summary>
        /// <param name="sku">Sku code</param>
        /// <returns>Selected product</returns>
        [HttpGet("GetBySku")]
        public ActionResult<Product> Get(int sku)
        {
            try
            {
                var result = _iProductApplication.GetBySku(sku);

                if (result != null)
                    return Ok(result);

                var msg = "Nenhum produto encontrado com este Sku";
                SimpleLog.Warning(msg);
                return BadRequest(msg);
            }
            catch (Exception ex)
            {
                SimpleLog.Error($"Error message: {ex.Message}. Inner exception: {ex.InnerException}.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method that create a new product in the databse
        /// </summary>
        /// <param name="productModel">The new product</param>
        /// <returns>Message of success or error</returns>
        [HttpPost("Create")]
        public ActionResult Post([FromBody]ProductModel productModel)
        {
            try
            {
                var product = iMapper.Map<ProductModel, Product>(productModel);

                _iProductApplication.Create(product);

                return Ok("Produto adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                SimpleLog.Error($"Error message: {ex.Message}. Inner exception: {ex.InnerException}!");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method that delete a product from the database
        /// </summary>
        /// <param name="sku">Sku code of the product that will be deleted</param>
        /// <returns>Message of success or error</returns>
        [HttpDelete("Delete")]
        public ActionResult Delete(int sku)
        {
            try
            {
                _iProductApplication.Delete(sku);

                return Ok("Produto deletado com sucesso!");
            }
            catch (Exception ex)
            {
                SimpleLog.Error($"Error message: {ex.Message}. Inner exception: {ex.InnerException}!");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method that update a product
        /// </summary>
        /// <param name="productModel">The product that will be updated</param>
        /// <returns>Message of success or error</returns>
        [HttpPut("Update")]
        public ActionResult Update([FromBody]ProductModel productModel)
        {
            try
            {
                var product = iMapper.Map<ProductModel, Product>(productModel);
                _iProductApplication.Update(product);

                return Ok("Produto atualizado com sucesso");
            }
            catch (Exception ex)
            {
                SimpleLog.Error($"Error message: {ex.Message}. Inner exception: {ex.InnerException}!");
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}