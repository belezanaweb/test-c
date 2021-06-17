using BoticarioAPI.Domain.Entities;
using BoticarioAPI.Domain.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Domain.Interfaces.Application
{
    public interface IProductApp
    {
        bool Add(NewProductTO newProduct);
        bool Update(NewProductTO product);
        Product Get(int sku);
        bool Delete(int sku);
    }
}
