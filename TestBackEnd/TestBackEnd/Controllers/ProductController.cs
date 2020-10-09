using BackendTest.Context;
using BackendTest.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetctWebApiTestBackEnd.BuidViewEntitie;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly BackEndTestContext _backEndTestContext;
        private BuildProductViewEntities _buildProductViewEntities;

        public ProductController(BackEndTestContext backEndTestContext)
        {
            _backEndTestContext = backEndTestContext;
        }

        private void CallBehaviors(Product product)
        {   
            product.Inventory.CalculeteQuantity();
            product.SetIsMarketable();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            var productfind = await _backEndTestContext.Products.FindAsync(product.Sku);

            if (productfind != null)
                return Ok("The informed product exist in the database.");

             CallBehaviors(product);

            await _backEndTestContext.Products.AddAsync(product);
            await _backEndTestContext.SaveChangesAsync();
            
            return Created(string.Empty,string.Format("Product with sku {0} was successfully created", product.Sku));
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            var productFind = await _backEndTestContext.Products.FindAsync(product.Sku);

            if (productFind == null)
                return Ok("The informed product does not exist in the database, it is not possible to edit it.");

            _backEndTestContext.Entry(productFind).State = EntityState.Detached;

            CallBehaviors(product);

            _backEndTestContext.Products.Update(product);
            await _backEndTestContext.SaveChangesAsync();
            return Ok(string.Format("Product with sku {0} was successfully edited", product.Sku));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Product product)
        {
            var productFind = await _backEndTestContext.Products.FindAsync(product.Sku); 

            if (productFind == null)
                return Ok("The informed product does not exist in the database, it is not possible to delete it.");

            _backEndTestContext.Entry(productFind).State = EntityState.Detached;

            _backEndTestContext.Products.Remove(product);
            await _backEndTestContext.SaveChangesAsync();
            return Ok(string.Format("The product with sku  {0} was successfully deleted", product.Sku));
        }

        [HttpGet("{sku}", Name = "GetProduct")]
        public async Task<IActionResult> Get(int sku)
        {
            var product = await _backEndTestContext.Products.FindAsync(sku);

            if (product == null)
                return  Ok(string.Format("The product with sku {0} does not exist in the database", sku));
            _buildProductViewEntities = new BuildProductViewEntities(product);
           
            return Ok(_buildProductViewEntities.Products.FirstOrDefault());
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtcs = await _backEndTestContext.Products.ToListAsync();
            _buildProductViewEntities = new BuildProductViewEntities(produtcs);
            return Ok(_buildProductViewEntities.Products);
        }

    }
}
