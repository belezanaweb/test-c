using BelezaNaWeb.Api.Requests;
using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Domain.Entities;

namespace BelezaNaWeb.Api.Infrastructure.Mappings
{
    public sealed class CreateProductMapping : GenericMapping<Product>
    {
        #region Constructors

        public CreateProductMapping()
            : base(nameof(CreateProductMapping))
        { }

        #endregion

        #region Overriden Methods

        public override void Configure()
        {
            CreateMap<CreateProductRequest, CreateProductCommand>();
            CreateMap<CreateProductInventoryRequest, CreateProductInventoryCommand>();
            CreateMap<CreateProductWarehouseRequest, CreateProductWarehouseCommand>();
        }

        #endregion
    }
}
