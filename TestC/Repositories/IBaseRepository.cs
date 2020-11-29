using System.Collections.Generic;
using System;

namespace TestC.Repositories
{
    public interface IBaseRepository<Model>: IDisposable
    {
        Model Insert(Model model);
        Model Update(Model model);
        void Delete(int sku);
        Model GetByID(int sku);
        List<Model> GetAll();
    }
}