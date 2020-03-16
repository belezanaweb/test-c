using BelezaNaWeb.TestC.Api.Models;
using System.Collections.Generic;

namespace BelezaNaWeb.TestC.Api.Data
{
    public interface IBdInMemory
    {
        IList<Product> Products { get; }
    }
}