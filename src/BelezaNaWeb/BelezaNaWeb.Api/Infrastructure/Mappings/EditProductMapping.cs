using BelezaNaWeb.Api.Requests;
using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Domain.Entities.Impl;

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
            CreateMap<EditProductRequest, EditProductCommand>()
                .ForMember(dest => dest.Warehouses, opts => opts.MapFrom(src => src.Inventory.Warehouses));

            CreateMap<EditProductWarehouseRequest, EditProductWarehouseCommand>();
        }

        #endregion
    }
}
