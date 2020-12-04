using BelezaNaWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Insert(Product obj);
        void Update(Product obj);
        void Delete(int sku);
        IList<Product> Select();
        Product Select(int sku);
        void SaveChanges();
    }
}
