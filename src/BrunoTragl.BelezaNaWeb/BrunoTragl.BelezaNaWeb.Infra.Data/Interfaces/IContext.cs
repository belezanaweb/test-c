using BrunoTragl.BelezaNaWeb.Domain.Model;
using System.Collections.Generic;

namespace BrunoTragl.BelezaNaWeb.Infra.Data.Interfaces
{
    public interface IContext
    {
        ICollection<Product> Products { get; set; }
    }
}
