using System;
using BelezaNaWeb.Domain.Products.Enums;

namespace BelezaNaWeb.Domain.Products.ValueObjects
{
    public class ProductInventoryWarehouse
    {
        private string _locality;
        public string Locality
        {
            get
            {
                return _locality;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception();

                _locality = value;
            }
        }

        public int Quantity { get; private set; }
        public ProductInventoryWarehouseType Type { get; private set; }

        public ProductInventoryWarehouse(string locality, int quantity, 
                                         ProductInventoryWarehouseType type)
        {
            Locality = locality;
            Quantity = quantity;
            Type = type;
        }
    }
}
