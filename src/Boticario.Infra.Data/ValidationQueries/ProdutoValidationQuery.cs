using Boticario.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Boticario.Infra.Data.ValidationQueries
{
    public static class ProdutoValidationQuery
    {
        public static Expression<Func<Produto, bool>> GetProdutoComMesmoSKU(int id, long sku)
        {
            return x => x.Id != id && x.Sku == sku;
        }
    }
}
