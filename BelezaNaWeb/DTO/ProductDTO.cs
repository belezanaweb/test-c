using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Entities
{
    public class ProductDTO : Product
    {
        private long sku { get; }
    }
}
