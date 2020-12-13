using Desafio.Domain.Models;
using System.Collections.Generic;

namespace Desafio.Domain.Interfaces
{
    public interface IWarehouseRepository
    {
        void Create(Warehouse warehouse);
        List<Warehouse> Read(int sku);
        void Delete(int sku);
    }
}