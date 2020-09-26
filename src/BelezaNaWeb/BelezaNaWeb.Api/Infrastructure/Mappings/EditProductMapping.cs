using BelezaNaWeb.Api.Requests;
using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Domain.Entities;

namespace BelezaNaWeb.Api.Infrastructure.Mappings
{
    public sealed class EditProductMapping : GenericMapping<Product>
    {
        #region Constructors

        public EditProductMapping()
            : base(nameof(EditProductMapping))
        { }

        #endregion

        #region Overriden Methods

        public override void Configure()
        {
            CreateMap<EditProductRequest, EditProductCommand>();
            CreateMap<EditProductInventoryRequest, EditProductInventoryCommand>();
            CreateMap<EditProductWarehouseRequest, EditProductWarehouseCommand>();
        }

        #endregion
    }
}
