using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Repositories
{
    public interface IProductRepository
    {        
        Entities.Product GetBySku(int sku);       
        void Create(Entities.Product product);
        void Update(Entities.Product product);
        void Delete(Entities.Product product);

    }
}
