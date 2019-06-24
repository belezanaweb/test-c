using BW.AplicationCore.Entities;
using BW.AplicationCore.Interfaces.Repositories;
using BW.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BW.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    { 
        public void Add(Product entity)
        {
            ProductMock.Add(entity);
        }

        public void Delete(int id)
        {
            ProductMock.Delete(id);
        }

        public Product Get(int id)
        {
            return ProductMock.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return ProductMock.GetAll();
        }

        public void Update(Product entity)
        {
            ProductMock.Update(entity);
        }
    }
}
