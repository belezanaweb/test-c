using DesafioBelezaNaWeb.Models;

namespace DesafioBelezaNaWeb.Repository
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>();

        public (bool, Product) GetProduct(long sku)
        {
            var (exists, product) = CheckIfProductExists(sku);
            if (exists)
            {
                product.Inventory.Quantity = _products.Select(p => p.Inventory.Warehouses
                    .Select(q => q.Quantity).Sum()).FirstOrDefault();

                if (product.Inventory.Quantity > 0)
                {
                    product.IsMarketable = true;
                }
            }

            return (exists, product);
        }

        public Product CreateProduct(Product product)
        {
            var productExist = _products.Where(p => p.Sku == product.Sku).Any();
            if (productExist)
                throw new Exception("Este produto já existe.");

            _products.Add(product);

            return product;
        }

        public void DeleteProduct(long sku)
        {
            var (exists, product) = CheckIfProductExists(sku);
            if (!exists)
                throw new Exception("Produto não encontrado!");

            _products.RemoveAll(p => p.Sku == sku);
        }

        public void EditProduct(Product product)
        {
            var (exists, producto) = CheckIfProductExists(product.Sku);
            if (!exists) throw new Exception("Produto não encontrado!");

            (from p in _products
             where p.Sku == product.Sku
             select p).ToList()
                .ForEach(p =>
                {
                     p.Name = product.Name;
                     p.Inventory = product.Inventory;
                });
        }

        private (bool, Product) CheckIfProductExists(long sku)
        {
            var product = _products.Where(p => p.Sku == sku).FirstOrDefault();
            if(product is null)
                return (false, product);

            return (true, product);
        }
    }
}
