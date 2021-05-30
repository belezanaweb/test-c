using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;

namespace Boticario.Domain.Search
{
    public class BaseSearch : ICustomQueryable
    {
        public int Page { get; set; } = 1;

        //[QueryOperator(Max = 100)]
        public int Limit { get; set; } = 50;
        //public string Sort { get; set; }
    }
}