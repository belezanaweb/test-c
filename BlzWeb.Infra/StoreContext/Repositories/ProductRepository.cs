using BlzWeb.Domain.StoreContext.Entities;
using BlzWeb.Domain.StoreContext.Repositories;
using BlzWeb.Infra.DataContexts;
using System.Collections.Generic;
using System.Linq;

namespace BlzWeb.Infra.StoreContext.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BlzWebDataContext _context;
        private IList<Product> _prodcts;
        public ProductRepository(BlzWebDataContext context)
        {
            _prodcts = new List<Product>
            {
                new Product(43264, "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",  new Inventory(15M)),
                new Product(43265, "Kit Mãe Radiante e Elegante (3 Produtos)", new Inventory(10M)),
                new Product(43266, "Conjunto 1 Million Masculino - Eau de Toilette 100ml + Desodorante 150ml", new Inventory(15M)),
                new Product(43267, "Instant Bronze Self-Tanning Lotion - Loção Autobronzeadora 130ml", new Inventory(15M)),
                new Product(43268, "Loção Auto-Bronzeante Spray - Spray Autobronzeador 100ml", new Inventory(15M))
            };
            _context = context;
        }

        public bool CheckSku(int sku)
        {
            return _prodcts.Any(c => c.Sku == sku);
        }

        public void Delete(int sku)
        {
            var produ = _prodcts.FirstOrDefault(c => c.Sku == sku);
            _prodcts.Remove(produ);
        }

        public Product Get(int sku)
        {
            return _prodcts.FirstOrDefault(c => c.Sku == sku);
        }

        public void Save(Product product)
        {
            _prodcts.Add(product);
        }

        public void Update(Product product)
        {
            var _product = _prodcts.FirstOrDefault(c => c.Sku == product.Sku);
            _product = product;
        }
    }
}