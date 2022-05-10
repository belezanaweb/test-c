using Core.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.ApiModels
{
    public class ProductCreateDTO
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryCreateDTO Inventory { get; set; }
        
        public ProductCreateDTO()
        {
            Inventory = new InventoryCreateDTO();
        }

        internal Product ToProduct() {

            var product = new Product();
            JsonConvert.PopulateObject(JsonConvert.SerializeObject(this), product);

            return product;
        }
    }

    public class InventoryCreateDTO
    {   
        public List<WarehouseCreateDTO> Warehouses { get; set; }
        public InventoryCreateDTO()
        {
            Warehouses = new List<WarehouseCreateDTO>();
        }
    } 

    public class WarehouseCreateDTO
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }

}
