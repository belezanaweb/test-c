using BackEndTest.Application.DTOs;
using BackEndTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;
        private readonly IWarehouseService _warehouseService;

        public ProductController(IProductService   productService,
                                 IInventoryService inventoryService,
                                 IWarehouseService warehouseService)
        {
            _productService = productService;
            _inventoryService = inventoryService;
            _warehouseService = warehouseService;
        }

        [HttpGet("{sku}")]
        public async Task<ActionResult<ProductDTO>> GetProductBySku(int sku)
        {
            var product = await _productService.GetProductBySku(sku);
            product.Inventory = await _inventoryService.GetInventoryByProductSku(sku);
            product.Inventory.Warehouses = await _warehouseService.GetWarehousesByProductSku(sku);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
