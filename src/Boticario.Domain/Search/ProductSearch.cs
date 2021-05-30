using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Boticario.Domain.Search
{
    public class ProductSearch : BaseSearch
    {
        [FromQuery(Name = "name"), QueryOperator(Operator = WhereOperator.Contains, CaseSensitive = false)]
        public string Name { get; set; }

        [FromQuery(Name = "sku"), QueryOperator(Operator = WhereOperator.Equals)]
        public int? Sku { get; set; }
    }
}
