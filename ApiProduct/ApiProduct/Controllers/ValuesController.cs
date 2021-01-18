using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiProduct.Models;
using ApiProduct.Controllers;
using System.Text;





namespace ApiProduct.Controllers
{
  
    public class ValuesController : ApiController
    {
        Product p = new Product();
        Inventory i = new Inventory();
        Warehouse w = new Warehouse();




        // GET api/values
        public Product GetProduct()
        {          
            

            return p;
           
        }

        // GET api/values/5
        public string Get(int id)
        {
            return p;
        }

        // POST api/values
        public void Post([FromBody]Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            List<Warehouse> warehouses = new List<Warehouse>(product.Inventory.Warehouses);

            i.Quantity = 0;
            p.IsMarketable = false;

            foreach (Warehouse post in warehouses)
            {
                w.Sku = product.Sku;
                w.Locality = post.Locality;
                w.Quantity = post.Quantity;
                w.Type = post.Type;
                i.Quantity = i.Quantity + w.Quantity;

            }

            i.Sku = product.Sku;
            i.Warehouses = warehouses;
            p.Sku = product.Sku;
            p.Name = product.Name;
            if (i.Quantity > 0)
            {
                p.IsMarketable = true;
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
