using BelezaNaWeb.Domain.Entities;

namespace BelezaNaWeb.Api.Infrastructure.Mappings
{
    public sealed class ProductMapping : GenericMapping<Product>
    {
        #region Constructors

        public ProductMapping()
            : base(nameof(ProductMapping))
        { }

        #endregion

        #region Overriden Methods

        public override void Configure()
        {

        }

        #endregion
    }
}
