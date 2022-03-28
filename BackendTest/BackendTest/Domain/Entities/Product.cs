using BackendTest.Domain.Commands.Requests;
using System;

namespace BackendTest.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public long Sku { get; set; }
        public string Name { get; set; }
        public virtual Inventory Inventory { get; set; }
        public bool IsMarketable { get { return Inventory.Quantity > 0; } }

        public void Atualizar(string name, Inventory inventory)
        {
            Name = name;
            Inventory.Atualizar(inventory.Warehouses);
        }
    }
}
