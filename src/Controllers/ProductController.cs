using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoBoticario.Data
{
    [ApiController]
    [Route("v1/Product")]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {

            var products = await context
            .Products
            .Include(x => x.Inventory)
            .Include(x => x.Inventory.Warehouses)
            .AsNoTracking()
            .ToListAsync();

            if (!products.Any())
                return NotFound(value: new { message = "Não há Produtos cadastrados" });

            return Ok(products);
        }

        [HttpGet]
        [Route("{sku:int}")]
        public async Task<ActionResult<Product>> GetBySku(int sku, [FromServices] DataContext context)
        {


            var products = await context
            .Products
            .Include(x => x.Inventory)
            .Include(x => x.Inventory.Warehouses)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Sku == sku);

            if (products == null)
                return NotFound(value: new { message = "Produto não cadastrado" });

            return Ok(products);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Product model, [FromServices] DataContext context)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

                var product = await context.Products.FirstOrDefaultAsync(x => x.Sku == model.Sku);

                if (product != null)
                    return NotFound(value: new { message = "SKU já cadastrado!" });

                context.Products.Add(model);
                await context.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Não foi possivel criar o produto - {ex.Message}" });
            }
        }


        [HttpPut]
        [Route("{sku:int}")]
        public async Task<ActionResult<Product>> Put(int sku, [FromBody] Product model, [FromServices] DataContext context)
        {

            if (sku != model.Sku)
                return NotFound(value: new { message = "Produto não encontrado" });

            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);

            try
            {
                if (model.Sku == sku)
                {
                    context.Entry<Product>(model).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = "produto não encontrado" });
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Não foi possivel editar o produto - {ex.Message}" });
            }
        }

        [HttpDelete]
        [Route("{sku:int}")]
        public async Task<ActionResult<Product>> Delete(int sku, [FromServices] DataContext context)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Sku == sku);
            if (product == null)
                return NotFound(new { message = "Produto Não encontrado" });

            try
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return Ok(new { Message = "Produto Removido com sucesso" });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel remover o Produto" });
            }

        }
    }
}