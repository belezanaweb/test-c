using BelezanaWeb.Interface.Repository.Base;
using BelezanaWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BelezanaWeb.Interface.Repository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        List<Product> GetWithWarehouses();
        List<Product> GetWithWarehouses(Expression<Func<Product, bool>> expression);
    }
}
