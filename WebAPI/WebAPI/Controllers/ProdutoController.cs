using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc_WebAPI_Demo.Models;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public List<Product> produtos = new List<Product>();

        public void Start()
        {
            //produtos 1
            Stock itemStock = new Stock();

            Product item = new Product
            {
                name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                sku = 43264,
            };

            produtos.Add(item);

            Warehouse itemWarehouse = new Warehouse
            {
                locality = "SP",
                quantity = 12,
                type = "ECOMMERCE"
            };

            produtos[0].inventory.warehouses.Add(itemWarehouse);

            itemWarehouse = new Warehouse
            {
                locality = "MOEMA",
                quantity = 3,
                type = "PHYSICAL_STORE"
            };
            produtos[0].inventory.warehouses.Add(itemWarehouse);
            produtos[0].inventory.Recalcular();

            //produto 2
            itemStock = new Stock();

            item = new Product
            {
                name = "Produto 1",
                sku = 1,
            };

            produtos.Add(item);

            itemWarehouse = new Warehouse
            {
                locality = "SP",
                quantity = 2,
                type = "ECOMMERCE"
            };

            produtos[1].inventory.warehouses.Add(itemWarehouse);

            itemWarehouse = new Warehouse
            {
                locality = "MOEMA",
                quantity = 3,
                type = "PHYSICAL_STORE"
            };
            produtos[1].inventory.warehouses.Add(itemWarehouse);
            produtos[1].inventory.Recalcular();
        }
               
        // GET api/produto/1
        [HttpGet("{id}")]
        public ActionResult<string> GetProduto(int id)
        {
            Start();

            var produto = produtos.FirstOrDefault(p => p.sku == id);
            produto.inventory.Recalcular();

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }
               
        //POST api/produto
        [HttpPost]
        public ActionResult<Product> PostProduto(Product item)
        {
            Start();

            //procura duplicidade
            var produto = produtos.FirstOrDefault(p => p.sku == item.sku);

            if (produto != null)
            {
                throw new InvalidOperationException("O Sku está cadastrado.");
            }
            item.inventory.Recalcular();
            produtos.Add(item);

            return CreatedAtAction(nameof(GetProduto), new { id = item.sku }, item);
        }
        
        // PUT api/produto/1   
        [HttpPut("{id}")]
        public IActionResult PutProduto(int id, Product item)
        {
            Start();
            var produto = produtos.FirstOrDefault(p => p.sku == id);
            if (id != item.sku)
            {
                return BadRequest();
            }
            produtos.Remove(produto);
            item.inventory.Recalcular();
            produtos.Add(item);

            return Ok(item);
        }

        // DELETE api/produto/1
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            Start();

            var produto = produtos.FirstOrDefault(p => p.sku == id);

            if (produto == null)
            {
                return NotFound();
            }

            produtos.Remove(produto);

            return Ok(true);
        }
    }
}
