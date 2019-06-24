using BW.AplicationCore.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BW.Infrastructure.Data
{
    public static class ProductMock
    {
        static Product productInitial = JsonConvert.DeserializeObject<Product>(@"{
                'sku': 43263,
                'name': 'teste 1 500g',
                'inventory': {
                    'warehouses': [
                        {
                            'locality': 'SP',
                            'quantity': 12,
                            'type': 'ECOMMERCE'
                        },
                        {
                            'locality': 'MOEMA',
                            'quantity': 3,
                            'type': 'PHYSICAL_STORE'
                        }
                    ]
                },
            }");

        private static List<Product> _products = new List<Product> { productInitial };

        public static void Add(Product entity)
        {
            _products.Add(entity);
        }

        public static void Update(Product entity)
        {
            var index = _products.FindIndex(x => x.Sku.Equals(entity.Sku));
            _products[index] = entity;
        }

        public static void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Sku.Equals(id));
            _products.Remove(product);
        }

        public static Product Get(int id)
        {
            return _products.FirstOrDefault(p => p.Sku.Equals(id));
        }

        public static IList<Product> GetAll()
        {
            return _products;
        }

    }
}
