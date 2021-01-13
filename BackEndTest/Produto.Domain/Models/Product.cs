using Produto.Domain.Validators;
using System;
using System.Collections.Generic;

namespace Produto.Domain.Models
{
    public class Product : Entity
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public Invenctory Invenctory { get; set; }
        public bool IsMarketable { get { return this.Invenctory?.Quantity > 0; } }

        internal Product(ProductBuilder productBuilder)
        {
            this.Sku = productBuilder.GetSku();
            this.Name = productBuilder.GetName();
            this.Invenctory = productBuilder.GetInvenctory();

            Validate(this, new ProductValidator());

        }

        public Product()
        {
        }
    }

    public class ProductBuilder
    {
        private String sku;
        private String name;
        private Invenctory invenctory;

        public String GetSku()
        {
            return sku;
        }

        public String GetName()
        {
            return name;
        }

        public Invenctory GetInvenctory()
        {
            return invenctory;
        }
    
        public ProductBuilder WithSku(string sku)
        {
            this.sku = sku;
            return this;
        }


        public ProductBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }

        public ProductBuilder WithInvenctory(Invenctory invenctory)
        {
            this.invenctory = invenctory;
            return this;
        }


        public Product Build()
        {
            return new Product(this);
        }


    }

    public class InvenctoryBuilder
    {
        private IList<WareHouse> wareHouses;

        public IList<WareHouse> GetWareHouses()
        {
            return this.wareHouses;
        }

        public InvenctoryBuilder WithWareHouses(IList<WareHouse> wareHouses)
        {
            this.wareHouses = wareHouses;
            return this;
        }

        public Invenctory Build()
        {
            return new Invenctory(this);
        }
    }
}
