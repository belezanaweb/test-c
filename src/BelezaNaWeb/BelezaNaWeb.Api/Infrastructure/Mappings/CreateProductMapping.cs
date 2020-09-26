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
            CreateMap<CreateProductRequest, CreateProductCommand>()
                .ForMember(dest => dest.Warehouses, opts => opts.MapFrom(src => src.Inventory.Warehouses));
            
            CreateMap<CreateProductWarehouseRequest, CreateProductWarehouseCommand>();
        }

        #endregion
    }
}
