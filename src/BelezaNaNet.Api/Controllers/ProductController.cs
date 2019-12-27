using BelezaNaNet.Api.Commands;
using BelezaNaNet.Api.Context;
using BelezaNaNet.Api.Inputs;
using BelezaNaNet.Api.Models;
using BelezaNaNet.Api.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaNet.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApiContext _context;
        public ProductController(ApiContext context)
        {
            _context = context;
        }
        // GET: api/products/5
        [HttpGet]
        [Route("{sku}")]
        public async Task<IActionResult> Get(double sku)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Sku == sku);
            return Ok(product);
        }
        // POST: api/products
        [HttpPost]
        public ICommandResult Post([FromBody] CreateProductInput input)
        {
            IList<Warehouse> warehouses = new List<Warehouse>();
            foreach (var warehouse in input.Inventory.Warehouses)
            {
                warehouses.Add(new Warehouse(warehouse.Locality, warehouse.Quantity, warehouse.Type));
            }
            var inventory = new Inventory(warehouses);
            var product = new Product(input.Sku, input.Name, inventory);

            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return new CommandResult($"O produto {product.Name} - SKU: {product.Sku} foi criado com sucesso!");
            }
            catch (Exception e)
            {
                return new CommandResult("Um item com este SKU já existe!");
            }
        }
        // PUT: api/products/5
        [HttpPut("{sku}")]
        public async Task<ICommandResult> Put(double sku, [FromBody] UpdateProductInput input)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Sku == sku);
            product.Update(input.Name, input.Inventory);

            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return new CommandResult($"O produto {product.Name} - SKU: {product.Sku} foi atualizado com sucesso!");
            }
            catch (Exception e)
            {
                return new CommandResult($"Ocorreu um erro ao atualizar o produto de SKU: {product.Sku}!");
            }
        }
        // DELETE: api/products/5
        [HttpDelete("{sku}")]
        public async Task<ICommandResult> Delete(double sku)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Sku == sku);

            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return new CommandResult($"O produto {product.Name} - SKU: {product.Sku} foi removido com sucesso!");
            }
            catch (Exception e)
            {
                return new CommandResult($"Ocorreu um erro ao remover o produto de SKU: {product.Sku}!");
            }
        }
    }
}
