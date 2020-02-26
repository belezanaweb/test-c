using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Produto.Models;

namespace WebAPI_Produto.Repository
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
        Produto Get(int id);
        Produto Add(Produto item);
        void Remove(int id);
        Produto Update(int id, Produto item);
    }
}
