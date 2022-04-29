using BackEndTest.Application.DTOs;
using BackEndTest.WebAPI.Models.JsonModels;

namespace BackEndTest.WebAPI.Utils
{
    public class ConvertDTOtoJson
    {
        public ProductJson ConvertProductDTOToJson(ProductDTO dto)
        {
            return new ProductJson
            {
                Name = dto.Name,
                Sku = dto.Sku,
                isMarketable = dto.isMarketable,
                Inventory = ConvertInventoryToJson(dto.Inventory, dto.Sku)
            };
        }

        private InventoryJson ConvertInventoryToJson(InventoryDTO inventoryDTO, int sku)
        {
            return new InventoryJson
            {
                Quantity = inventoryDTO.Quantity,
                Warehouses = ConvertWarehousesToJson(inventoryDTO.Warehouses, sku)
            };
        }

        private List<WarehouseJson> ConvertWarehousesToJson(List<WarehouseDTO> warehousesDTO, int sku)
        {
            List<WarehouseJson> warehousesJson = new List<WarehouseJson>();
            foreach (var warehouseDTO in warehousesDTO)
            {
                WarehouseJson warehouseJson = new WarehouseJson
                {
                    Locality = warehouseDTO.Locality,
                    Quantity = warehouseDTO.Quantity,
                    Type = warehouseDTO.Type
                };
                warehousesJson.Add(warehouseJson);
            }
            return warehousesJson;
        }
    }
}
