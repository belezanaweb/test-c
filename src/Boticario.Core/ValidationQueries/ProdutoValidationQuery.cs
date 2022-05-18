using Boticario.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Boticario.Core.ValidationQueries
{
    public static class ProdutoValidationQuery
    {
        public static Expression<Func<Produto, bool>> GetProdutoComMesmoSKU(long sku, int? id = null)
        {
            if (id != null)
            {
                return x => x.Id != id && x.Sku == sku;
            }

            return x => x.Sku == sku;
        }

        public static Expression<Func<Produto, bool>> GetBySku(long sku)
        {
            return x => x.Sku == sku;
        }
    }
}
