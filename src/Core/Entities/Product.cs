using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }

        public bool isMarketable => GetIsMarketable();


        public Product Clone()
        {
            var serializedObject = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Product>(serializedObject);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Product);
        }
        public bool Equals(Product obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.Sku == obj.Sku)
            {
                return base.Equals((Product)obj);
            }
            else
            {
                return false;
            }
        }


        public override int GetHashCode()
        {
            return (Sku).GetHashCode();
        }

        private bool GetIsMarketable()
        {
            if (Inventory is null)
                return false;

            return (Inventory.Quantity > 0);
        }
    }
}
