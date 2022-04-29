using BackEndTest.Application.DTOs;
using BackEndTest.WebAPI.Models.JsonModels;

namespace BackEndTest.WebAPI.Utils
{
    public class ConvertJsonToDTO
    {
        public ProductDTO ConvertProductJsonToDTO(ProductJson json)
        {
            return new ProductDTO
            {
                Id = 0,
                Name = json.Name,
                Sku = json.Sku,
                isMarketable = json.isMarketable,
                Inventory = ConvertInventoryToDTO(json.Inventory, json.Sku)
            };
        }

        private InventoryDTO ConvertInventoryToDTO(InventoryJson inventoryJson, int sku)
        {
            return new InventoryDTO
            {
                Id = 0,
                ProductSku = sku,
                Quantity = inventoryJson.Quantity,
                Warehouses = ConvertWarehousesToDTO(inventoryJson.Warehouses, sku)
            };
        }

        private List<WarehouseDTO> ConvertWarehousesToDTO(List<WarehouseJson> warehousesJson, int sku)
        {
            List<WarehouseDTO> warehousesDTO = new List<WarehouseDTO>();
            foreach (var warehouseJson in warehousesJson)
            {
                WarehouseDTO warehouseDTO = new WarehouseDTO
                {
                    Id = 0,
                    ProductSku = sku,
                    Locality = warehouseJson.Locality,
                    Quantity = warehouseJson.Quantity,
                    Type = warehouseJson.Type
                };
                warehousesDTO.Add(warehouseDTO);
            }
            return warehousesDTO;
        }
    }
}
