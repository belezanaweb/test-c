using BackEndTest.Application.DTOs;
using BackEndTest.Application.Interfaces;
using BackEndTest.WebAPI.Models.JsonModels;
using BackEndTest.WebAPI.Utils;
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
        private ConvertJsonToDTO convertToDTO = new ConvertJsonToDTO();
        private ConvertDTOtoJson convertToJson = new ConvertDTOtoJson();

        public ProductController(IProductService   productService,
                                 IInventoryService inventoryService,
                                 IWarehouseService warehouseService)
        {
            _productService = productService;
            _inventoryService = inventoryService;
            _warehouseService = warehouseService;
        }

        //Pegar produto por SKU
        [HttpGet("{sku}")]
        public async Task<ActionResult<ProductDTO>> GetProductBySku(int sku)
        {
            var product = await _productService.GetProductBySku(sku);
            
            if (product == null) return NotFound();
            
            product.Inventory = await _inventoryService.GetInventoryByProductSku(sku);
            product.Inventory.Warehouses = await _warehouseService.GetWarehousesByProductSku(sku);
            
            return Ok(convertToJson.ConvertProductDTOToJson(product));
        }

        //Adicionar produto
        [HttpPost]
        public async Task<ActionResult<ProductJson>> CreateProduct([FromBody] ProductJson productJson)
        {
            ProductDTO productDTO = convertToDTO.ConvertProductJsonToDTO(productJson);
            //Verifica se produto a ser criado veio nulo
            if (productDTO == null) return BadRequest("Produto não existe");

            //Verifica se Sku possui valor válido
            if (productDTO.Sku <= 0) return BadRequest("Sku menor ou igual a zero");

            //Verifica se já existe outro produto com o mesmo Sku
            if(_productService.CheckExistingSku(productDTO.Sku)) return BadRequest("Já existe produto igual cadastrado");

            bool bWarehouseResult = await _warehouseService.CreateWarehouses(productDTO.Inventory.Warehouses, productDTO.Sku);

            //Verifica se os Warehouses foram adicionados com êxito
            if (!bWarehouseResult) return BadRequest();

            //Ajusta campos quantity em inventory e isMarketable
            productDTO = AdjustAmountAndMarketAble(productDTO);

            bool bInventoryResult = await _inventoryService.CreateInventory(productDTO.Inventory, productDTO.Sku);

            //Verifica se os Inventários foram adicionados com êxito
            if (!bInventoryResult) return BadRequest();

            bool bProductResult = await _productService.CreateProduct(productDTO);

            //Verifica se os Produtos foram adicionados com êxito
            if (!bProductResult) return BadRequest();
            
            return Ok(productJson);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{sku}")]
        public async Task<ActionResult<ProductJson>> UpdateProduct(int sku, [FromBody] ProductJson productJson)
        {
            ProductDTO productDTO = convertToDTO.ConvertProductJsonToDTO(productJson);
            //Verifica se produto a ser atualizado veio nulo
            if (productDTO == null) return BadRequest("Produto não existe");

            //Verifica se Sku possui valor válido
            if (productDTO.Sku <= 0) return BadRequest("Sku menor ou igual a zero");

            bool bWarehouseResult = await _warehouseService.UpdateWarehousesBySku(productDTO.Inventory.Warehouses);

            //Verifica se os Warehouses foram atualizados com êxito
            if (!bWarehouseResult) return BadRequest();

            //Ajusta campos quantity em inventory e isMarketable
            productDTO = AdjustAmountAndMarketAble(productDTO);

            bool bInventoryResult = await _inventoryService.UpdateInventoryByProductSku(productDTO.Inventory);

            //Verifica se os Inventários foram atualizados com êxito
            if (!bInventoryResult) return BadRequest();

            bool bProductResult = await _productService.UpdateProductBySku(productDTO);

            //Verifica se os Produtos foram atualizados com êxito
            if (!bProductResult) return BadRequest();

            return Ok(productJson);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{sku}")]
        public async Task<ActionResult> DeleteProductById(int sku)
        {
            var statusWarehouse = await _warehouseService.RemoveWarehousesByProductSku(sku);
            if (!statusWarehouse) return BadRequest();

            var statusInventory = await _inventoryService.RemoveInventoryByProductSku(sku);
            if (!statusInventory) return BadRequest();

            var statusProduct = await _productService.RemoveProductBySku(sku);
            if (!statusProduct) return BadRequest();

            return Ok("Produto deletado com sucesso");
        }

        //Atualizar quantidade total e campo booleano de comercializável
        private ProductDTO AdjustAmountAndMarketAble(ProductDTO productDTO)
        {
            var product = productDTO;
            int quantity = 0;
            var warehouses = productDTO.Inventory.Warehouses;

            foreach (var warehouse in warehouses)
            {
                quantity = quantity + warehouse.Quantity;
            }

            if (quantity > 0) product.isMarketable = true;
            else product.isMarketable = false;

            product.Inventory.Quantity = quantity;

            return product;
        }
    }
}
