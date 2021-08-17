using System;
using System.Collections.Generic;
using System.Text;

namespace TesteVagaBoticario.Negocio.Interfaces
{
    public interface IRepositoryProduct : IRepository<Product>
    {
        bool Exist(int sku);
    }
}
