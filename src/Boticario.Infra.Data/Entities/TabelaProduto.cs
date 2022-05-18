using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Infra.Data.Entities
{
    public class TabelaProduto
    {
        public TabelaProduto()
        {
            TabelaEstoque = new List<TabelaEstoque>();
        }

        public int Id { get; set; }

        public long Sku { get; set; }

        public string Nome { get; set; }

        public virtual IList<TabelaEstoque> TabelaEstoque { get; set; }
}
}
