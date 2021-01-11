using AutoMapper;

using BNWTC.Api.Models.Entities;
using BNWTC.Api.Services.IServices;
using BNWTC.Api.ViewModel;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace BNWTC.Api.Controllers
{
    [Route("v1/produtos")]
    public class ProductController : ControllerBase
    {
        private readonly IProductSerices _productSerices;
        private readonly IMapper _mapper;

        public ProductController(IProductSerices productSerices, IMapper mapper)
        {
            _productSerices = productSerices;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{sku:int}")]
        public async Task<ActionResult<ProductViewModel>> GetBySku(int sku)
        {
            var product = await _productSerices.FindBySku(sku);

            return Ok(product);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ProductViewModel>> Post([FromBody] ProductViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var SkuExist = await SkuExistsAsync(model.Sku);
            if (SkuExist)
                return NotFound(new { message = "Sku do Produto já utilizado" });

            try
            {
                var product = new Product();

                product = await _productSerices.Add(_mapper.Map<Product>(model));

                return CreatedAtAction(actionName: nameof(Post), routeValues: new { sku = model.Sku }, value: model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<bool> SkuExistsAsync(int sku)
        {
            var product = await _productSerices.FindBySku(sku);

            if (product == null)
                return false;

            return true;
        }
    }
}
