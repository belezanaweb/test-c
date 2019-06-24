using BW.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BW.AplicationCore.Interfaces.Services
{
    public interface IProductService
    {
        void Add(Product entity);
        void Update(Product entity);
        Product Get(int id);
        IEnumerable<Product> GetAll();
        void Delete(int id);

    }
}
