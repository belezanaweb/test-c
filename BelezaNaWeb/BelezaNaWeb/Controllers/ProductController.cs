using System.Net;
using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Response;
using BelezaNaWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace BelezaNaWeb.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponse<Product>>> Create([FromBody] Product? product)
        {
            var response = new BaseResponse<Product>();
            try
            {
                response = await _productService.CreateProduct(product);
                return StatusCode((int)response.HttpStatusCode, response);
            }
            catch (Exception ex)
            {
                response.HttpStatusCode = HttpStatusCode.InternalServerError;
                throw ex;
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<BaseResponse<Product>>> GetAll()
        {
            var response = new BaseResponse<Product>();
            try
            {
                response = await _productService.GetAllProducts();
                return StatusCode((int)response.HttpStatusCode, response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetBySku")]
        public async Task<ActionResult<BaseResponse<Product>>> GetBySku(int sku)
        {
            var response = new BaseResponse<Product>();
            try
            {
                response = await _productService.GetBySku(sku);
                return StatusCode((int)response.HttpStatusCode, response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("DeleteBySku")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBySku(int sku)
        {
            var response = new BaseResponse<bool>();
            try
            {
                response = await _productService.DeleteProductBySku(sku);
                return StatusCode((int)response.HttpStatusCode, response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateBySku")]
        public async Task<ActionResult<BaseResponse<bool>>> UpdateBySku(int sku, [FromBody] Product? product)
        {
            var response = new BaseResponse<bool>();
            try
            {
                response = await _productService.UpdateBySku(sku, product);
                return StatusCode((int)response.HttpStatusCode, response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}