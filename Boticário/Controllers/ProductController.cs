using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ApiContext _context;

        public ProductController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _context.Products
                .Include(x => x.ProductWarehouse)
                .Select(x => MapProductToModel(x))
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBySku(int id)
        {
            var product = await GetProduct(id);

            if (product != null)
            {
                return Ok(MapProductToModel(product));
            }

            return NotFound();

        }

        private async Task<Product> GetProduct(int sku)
        {
            return await _context.Products.Include(x => x.ProductWarehouse).FirstOrDefaultAsync(x => x.SKU == sku);
        }

        private static ReturnProductViewModel MapProductToModel(Product product)
        {
            return new ReturnProductViewModel
            {
                SKU = product.SKU,
                Name = product.Name,
                Inventory = new ReturnInventory
                {
                    Quantity = product.ProductWarehouse.Sum(x => x.Quantity),
                    Warehouses = product.ProductWarehouse.Select(x => new Warehouse
                    {
                        Quantity = x.Quantity,
                        Locality = x.Locality,
                        Type = x.Type
                    }).ToList()
                },
                isMarketable = product.ProductWarehouse.Sum(x => x.Quantity) > 0
            };
        }

        private static Product MapModelToProduct(ProductViewModel model)
        {
            return new Product
            {
                SKU = model.SKU,
                Name = model.Name,
                ProductWarehouse = model
                    .Inventory
                    .Warehouses
                    .Select(x => new ProductWarehouse
                    {
                        Locality = x.Locality,
                        Quantity = x.Quantity,
                        Type = x.Type
                    }).ToList()
            };
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            var exists = await GetProduct(model.SKU);

            if (exists != null)
            {
                return BadRequest("Dois produtos são considerados iguais se os seus skus forem iguais");
            }

            var product = MapModelToProduct(model);

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return Ok(MapProductToModel(product));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(int id, ProductViewModel model)
        {
            var oldProduct = await GetProduct(id);
            if (oldProduct != null)
            {
                var newProduct = MapModelToProduct(model);

                oldProduct.Name = newProduct.Name;
                oldProduct.ProductWarehouse = newProduct.ProductWarehouse;

                await _context.SaveChangesAsync();

                return Ok(MapProductToModel(oldProduct));
            }

            return NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await GetProduct(id);

            if (exists != null)
            {
                _context.Remove(exists);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}
