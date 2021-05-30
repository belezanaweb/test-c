using System;
using System.ComponentModel.DataAnnotations;

namespace Boticario.Domain.Models
{
    public class Products: EntityBase
    {
        public Products()  { }
        public Products(Guid id, string name, int sku) : base(id)
        {            
            this.Name = name;
            this.Sku  = sku;
            this.Inventory = new Inventory();
        }

        public void SetSku(int sku)
        {
            this.Sku = sku;
        }

        public void VerifyIsMarketable()
        {
            this.IsMarketable = Inventory != null && Inventory.Quantity > 0;
        }

        
        public int Sku { get; private set; }


        [Required(ErrorMessage = "Campo Name é obrigatório")]
        public string Name { get; private set; }
        public Inventory Inventory { get; private set; }
        public bool IsMarketable { get; private set; }
    }
}
