using BelezanaWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BelezanaWeb.Business.Interfaces
{
    public interface IProductBusiness
    {
        Product Get(int id);
        List<Product> Get();
        Product Insert(Product product);
        Product Update(int id, Product product);
        Product Delete(int id);
    }
}