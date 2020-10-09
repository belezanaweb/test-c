using AutoMapper;
using BelezaNaWebApi.Model;
using BelezaNaWebDomain;
using BelezaNaWebDomain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelezaNaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProductModel>> Get()
        {
            var entities = await _productService.ListAsync();

            var models = _mapper.Map<IEnumerable<ProductModel>>(entities);

            return Ok(models);
        }

        [HttpGet("{sku}")]
        public async Task<ActionResult> Get(long sku)
        {
            var entity = await _productService.GetProductAsync(sku);
            if (entity == null)
                return NotFound();

            var model = _mapper.Map<ProductModel>(entity);
            return Ok(model);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductModel value)
        {
            try
            {
                var entity = _mapper.Map<Product>(value);
                _productService.AddProduct(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut("{sku}")]
        public ActionResult Put(long sku, [FromBody] ProductModel value)
        {
            try
            {
                if (!(sku > 0) || !(value?.SKU > 0) || (sku != value?.SKU))
                    return BadRequest("SKU incorreto!");

                var entity = _mapper.Map<Product>(value);
                _productService.UpdateProduct(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{sku}")]
        public ActionResult Delete(long sku)
        {
            try
            {
                _productService.DeleteProduct(sku);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}