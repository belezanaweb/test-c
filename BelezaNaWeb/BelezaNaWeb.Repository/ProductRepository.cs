using BelezaNaWeb.Domain.Entities;

namespace BelezaNaWeb.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> Products = new();

        public Product? GetBySku(int sku) => Products.FirstOrDefault(p => p.Sku == sku);

        public List<Product> GetProducts() => Products.ToList();

        public Product Create(Product? product)
        {
            if (Products.All(p => p.Sku != product.Sku))
                Products.Add(product);
            return product;
        }

        public void UpdateBySku(int sku, Product newProduct)
        {
            var currentProduct = GetBySku(sku);
            if (currentProduct is not null) return;
            if (newProduct != null && sku != newProduct.Sku) return;
            DeleteBySku(sku);
            Products.Add(newProduct);
        }

        public void DeleteBySku(int sku)
        {
            Products.RemoveAll(p => p.Sku == sku);
        }
    }
}
