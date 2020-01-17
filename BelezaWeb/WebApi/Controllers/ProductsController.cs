using System;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller for products
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Fields

        private readonly IProductService _productService;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>     
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetProducts")]        
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]      
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _productService.GetProducts();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]ProductDTO product)
        {
            try
            {
                var productExists = _productService.ProductExists(product.Sku).Result;

                if (productExists)
                {
                    return BadRequest(new Exception("Já existe produto cadastrado para o SKU enviado"));
                }

                var response = await _productService.CreateProduct(product);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Edit a product
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("{sku}", Name = "EditProduct")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int sku, [FromBody]ProductDTO product)
        {
            try
            {
                var response = await _productService.EditProduct(sku, product);

                if (response == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get a product
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        [HttpGet("{sku}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int sku)
        {
            try
            {
                var response = await _productService.GetProduct(sku);

                if (response == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        [HttpDelete("{sku}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int sku)
        {
            try
            {
                var response = await _productService.DeleteProduct(sku);

                if (response == false)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion
    }

}
