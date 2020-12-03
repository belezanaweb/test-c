using BrunoTragl.BelezaNaWeb.Domain.Model;
using BrunoTragl.BelezaNaWeb.Infra.Data.Interfaces;
using System.Collections.Generic;

namespace BrunoTragl.BelezaNaWeb.Infra.Data
{
    public class Context : IContext
    {
        public Context()
        {
            Products = new List<Product>();
        }
        public ICollection<Product> Products { get; set; }
    }
}
