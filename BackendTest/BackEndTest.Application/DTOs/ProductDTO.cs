using BackEndTest.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndTest.Application.DTOs
{
    public class ProductDTO
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public bool isMarketable { get; set; }
        public int InventoryId { get; set; }
        public InventoryDTO Inventory { get; set; }
    }
}
