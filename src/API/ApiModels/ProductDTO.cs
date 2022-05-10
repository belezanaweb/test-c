using Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.ApiModels
{
    public class ProductDTO
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryDTO Inventory { get; set; }
        public bool IsMarketable {get; internal set; }  

        public ProductDTO()
        {
            this.Inventory = new InventoryDTO();
        }

        internal static ProductDTO FromProduct(Product product)
        {
            var productDto = new ProductDTO();
            JsonConvert.PopulateObject(JsonConvert.SerializeObject(product), productDto);

            return productDto;
        }
    }

    public class InventoryDTO
    {
        public int Quantity { get; internal set; }

        public List<WarehouseDTO> Warehouses { get; set; }

        public InventoryDTO()
        {
            this.Warehouses = new List<WarehouseDTO>();
        }

      

    }

    public class WarehouseDTO
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }

}
