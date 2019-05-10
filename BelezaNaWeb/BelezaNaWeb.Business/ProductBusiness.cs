
using BelezaNaWeb.Data;
using BelezaNaWeb.Domain;
using System.Collections.Generic;

namespace BelezaNaWeb.Business
{
    public class ProductBusiness
    {
        private ProductData Data { get; set; } = new ProductData();

        public void Add(Product product)
        {
            Data.Add(product);
        }

        public List<Product> GetAll()
        {
            return Data.GetAll();
        }

        public Product GetById(int sku)
        {
            return Data.GetById(sku);
        }

        public void Update(Product product)
        {
            Data.Update(product);

        }

        public void Delete(int sku)
        {
            Data.Delete(sku);
        }
    }
}
