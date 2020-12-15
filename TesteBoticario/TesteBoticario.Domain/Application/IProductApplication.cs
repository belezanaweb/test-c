using System;
using System.Collections.Generic;
using System.Text;
using TesteBoticario.Domain.Dto;

namespace TesteBoticario.Domain.Application
{
    public interface IProductApplication
    {
        void Add(Product entity);

        void Update(Product entity);

        bool Delete(int sku);

        Product Get(int sku);
    }
}
