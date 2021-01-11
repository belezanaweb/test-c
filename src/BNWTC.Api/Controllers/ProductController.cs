using AutoMapper;

using BNWTC.Api.Models.Entities;
using BNWTC.Api.Services.IServices;
using BNWTC.Api.ViewModel;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace BNWTC.Api.Controllers
{
    [Route("v1/products")]
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
                return BadRequest(modelState: ModelState);

            var SkuExist = await SkuExistsAsync(sku: model.Sku);
            if (SkuExist)
                return NotFound(value: new { message = "Product sku in use" });

            try
            {
                var product = new Product();
                product = await _productSerices.Add(_mapper.Map<Product>(model));

                return CreatedAtAction(actionName: nameof(Post), routeValues: new { sku = model.Sku }, value: model);
            }
            catch
            {
                return BadRequest(error: new { message = "Could not create Product" });
            }
        }

        [HttpPut]
        [Route("{sku:int}")]
        public async Task<ActionResult<ProductViewModel>> Put(int sku, [FromBody] ProductViewModel model)
        {
            if (model.Sku != sku)
                return NotFound(value: new { message = "Product not found" });

            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);

            try
            {
                var product = new Product();
                product = await _productSerices.Update(product: _mapper.Map<Product>(model));

                return Ok(value: model);
            }
            catch (DbUpdateConcurrencyException)
            {
                var SkuExist = await SkuExistsAsync(sku: model.Sku);
                if (SkuExist)
                    return NotFound(value: new { message = "Product sku in use" });

                return BadRequest(error: new { message = "Could not modify product" }); 
            }
            catch
            {
                return BadRequest(error: new { message = "Could not modify product" });
            }
        }

        private async Task<bool> SkuExistsAsync(int sku)
        {
            var product = await _productSerices.FindBySku(sku: sku);

            if (product == null)
                return false;

            return true;
        }
    }
}
