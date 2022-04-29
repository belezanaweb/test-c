using BackEndTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndTest.Application.DTOs
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public int ProductSku { get; set; }
        public int Quantity { get; set; }
        public List<WarehouseDTO> Warehouses { get; set; }
    }
}
