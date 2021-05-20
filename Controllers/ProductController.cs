using AutoMapper;
using Inventory.api.Data;
using Inventory.api.Models;
using Inventory.api.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Inventory.api.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var product = await context.Products.Include(x => x.inventory).Include(x => x.inventory.warehouses)
                .ToListAsync();
            return product;
        }

        [HttpGet]
        [Route("{sku:int}")]
        public async Task<ActionResult<Product>> Get([FromServices] DataContext context, int sku)
        {

            var product = await context.Products.Include(x => x.inventory).Include(x => x.inventory.warehouses)
                .FirstOrDefaultAsync(x => x.sku == sku);

            return product;
        }

        [HttpPut]
        [Route("{sku:int}")]
        public async Task<ActionResult<Product>> Put([FromServices] DataContext context, [FromBody] Product model, int sku)
        {
            var product = await context.Products.Include(x => x.inventory).Include(x => x.inventory.warehouses)
                .FirstOrDefaultAsync(x => x.sku == sku);

            if (model.sku != sku || product == null)
            {
                return BadRequest();
            }

            model.id = product.id;
            model.inventory.id = product.inventory.id;
            context.Products.Update(model);
            await context.SaveChangesAsync();
           
            return model;
        }

        [HttpDelete]
        [Route("{sku:int}")]
        public async Task<ActionResult<Product>> Delete([FromServices] DataContext context, int sku)
        {
            var product = await context.Products.Include(x => x.inventory).Include(x => x.inventory.warehouses)
                .FirstOrDefaultAsync(x => x.sku == sku);

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return product;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(
            [FromServices] DataContext context,
            [FromBody] Product model)
        {
            var product = await context.Products.Include(x => x.inventory).Include(x => x.inventory.warehouses)
              .FirstOrDefaultAsync(x => x.sku == model.sku);

            if (product != null)
            {
                throw new System.ArgumentException("sku: " + product.sku.ToString() + " duplicada", "sku");
            }

            if (ModelState.IsValid)
            {
                context.Products.Add(model);
                await context.SaveChangesAsync();
              

                return StatusCode((int)HttpStatusCode.Created, _mapper.Map<ProductResponse>(model));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
