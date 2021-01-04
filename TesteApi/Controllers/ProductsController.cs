using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET api/<ProductsController>/
        [HttpGet("GetById/{sku}")]
        public ActionResult GetById(int sku)
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
               .UseInMemoryDatabase(databaseName: "InMemoryProvider")
               .Options;

            using (var context = new ApiContext(options))
            {
                var product = (from c in context.Products where c.Sku == sku select c).FirstOrDefault();

                if (product == null)
                {
                    return NotFound();
                }
                else
                {
                    var inventory = new Inventory();
                   
                    var warehouses = (from w in context.Warehouses where w.ProductId == product.Sku select w).ToList();

                    inventory.Warehouses = warehouses;
                    inventory.Quantity = warehouses.Sum(x => x.Quantity);
                    product.Inventory = inventory;
                    product.IsMarketable = inventory.Quantity > 0;                    
                }

                return Ok(product);
            }
        }


        // GET api/<ProductsController>
        [HttpGet("GetALL")]
        public ActionResult GetALL()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
               .UseInMemoryDatabase(databaseName: "InMemoryProvider")
               .Options;

            using (var context = new ApiContext(options))
            {
                var products = (from c in context.Products where c.Sku > 0 select c).ToList();

                if (products == null)
                {
                    return NotFound();
                }
                else
                {
                    var inventory = new Inventory();                  

                    foreach (var p in products)
                    { 
                        var warehouses = (from w in context.Warehouses where w.ProductId == p.Sku select w).ToList();
                                               
                        inventory.Warehouses = warehouses;
                        inventory.Quantity = warehouses.Sum(x => x.Quantity);  
                        p.Inventory = inventory;
                        p.IsMarketable = inventory.Quantity > 0;
                    }
                }  
                return Ok(products);
            }
        }

        
        [HttpPost("SaveNewProduct")]
        public string SaveNewProduct(Product product)
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
              .UseInMemoryDatabase(databaseName: "InMemoryProvider")
              .Options;

            using (var context = new ApiContext(options))
            {
                var p = (from c in context.Products where c.Sku == product.Sku select c).FirstOrDefault();

                if (p == null)
                {
                    foreach (var ware in product.Inventory.Warehouses)
                    {
                        ware.ProductId = product.Sku;
                    }

                    context.Products.Add(product);  
                    context.SaveChanges();

                    return "Product saved successfully";
                }
                else
                {
                    return "Product already exists";
                }
            }          
        }

        // PUT api/<ProductsController>/
        [HttpPut("UpdateProduct")]
        public ActionResult UpdateProduct(Product product)
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryProvider")
            .Options;

            using (var context = new ApiContext(options))
            { 
                //As I am using "In Memory" from EFCore, the product is updated by the "sku" without having to ask for.
                context.Products.Update(product);
                context.SaveChanges();

                return Ok("Cliente Atualizado com sucesso");
            }
        }

        // DELETE api/<ProductsController>/
        [HttpDelete("DeleteProduct/{id}")]
        public string DeleteProduct(int id)
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
           .UseInMemoryDatabase(databaseName: "InMemoryProvider")
           .Options;

            using (var context = new ApiContext(options))
            {
                var product = context.Products.Find(id);                
                context.Products.Remove(product);
                context.SaveChanges();

                return "Product deleted successfully";
            }
        }
    }
}
