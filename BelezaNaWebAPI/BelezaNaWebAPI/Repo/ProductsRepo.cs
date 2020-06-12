using AutoMapper;
using BelezaNaWebAPI.Exceptions;
using BelezaNaWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWebAPI.Repo
{
    public class ProductsRepo : IProductsRepo
    {
        readonly List<Product> products = new List<Product>();

        IMapper Mapper { get; }

        public ProductsRepo(IMapper mapper)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IQueryable<Product> Get()
        {
            return products.Select(Mapper.Map<Product>).AsQueryable();
        }

        public void Create(Product p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));

            if (products.Any(x => x.sku == p.sku))
            {
                throw new DuplicateKeyException($"Não é possível criar produto com o SKU '{p.sku}'. Já existe um objeto com o mesmo SKU.");
            }

            products.Add(Mapper.Map<Product>(p));
        }

        public void Delete(int sku)
        {
            var p = products.FirstOrDefault(x => x.sku == sku);
            if (p == null)
            {
                throw new KeyNotFoundException($"Um produto com o SKU '{sku}' não foi encontrado!");
            }

            products.RemoveAll(x => x.sku == p.sku);
        }

        public void Update(Product p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));

            var stored = products.FirstOrDefault(x => x.sku == p.sku);
            if (stored == null)
            {
                throw new KeyNotFoundException($"Um produto com o SKU '{p.sku}' não foi encontrado!");
            }

            products.RemoveAll(x => x.sku == stored.sku);
            products.Add(Mapper.Map<Product>(p));
        }
    }
}
