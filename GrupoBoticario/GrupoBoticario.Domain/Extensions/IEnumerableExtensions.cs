using GrupoBoticario.Domain.Payload.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoBoticario.Domain.Extensions
{
    public static class IEnumerableExtensions
    {
        public static string Agrupar(this IEnumerable<string> source, string separador = ".")
        {
            if (source.IsNullOrEmpty()) { return string.Empty; }

            return string.Join(separador, source);
        }

        public static bool IsNullOrEmpty(this IEnumerable<string> source)
        {
            return source is null is true || source.Any() is false;
        }

        public static bool ObterSkuDuplicados(this IEnumerable<ProductUpdatePayload> source)
        {
            return source
                .Select(x => x.Sku)
                .GroupBy(s => s)
                .Any(c => c.Count() > 1);
        }
    }
}
