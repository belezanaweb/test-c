using BelezaNaWeb.API.Models;
using System.Collections.Generic;

namespace BelezaNaWeb.API
{
    public class ProductContext
    {
        private readonly List<Product> _products;

        public ProductContext()
        {
            _products = new List<Product>();
        }

        public List<Product> Products { get { return _products; } }
    }
}
