using System;
using System.Linq;
using BlzWeb.Shared.Entities;
using FluentValidator;

namespace BlzWeb.Domain.StoreContext.Entities
{
    public sealed class Product : Entity
    {
        public Product(int sku, string name, Inventory inventory)
        {
            Sku = sku;
            Name = name;         
            Inventory = inventory;
        }

        public int Sku { get; private set; }
        public string Name { get; private set; }
        public bool IsMarketable { get; private set; }
        public Inventory Inventory { get; private set; }

        public override string ToString()
        {
            return $"Nome do Produto { Name } | Quantidade { Inventory.Quantity }";
        }


        public void CalculateInventory()
        {
             Inventory = new Inventory(Inventory.Warehouses.Sum(c => c.Quantity));
        }

        public void ChangeIsMarketable()
        {
            IsMarketable = Inventory.Quantity > 0;
        }
    }
}