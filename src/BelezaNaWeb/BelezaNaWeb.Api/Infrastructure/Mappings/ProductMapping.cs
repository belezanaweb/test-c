using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Api.Contracts.Requests;

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
            CreateMap<CreateProductRequest, Product>()
                .ForMember(dest => dest.Sku, opts => opts.MapFrom(src => src.Sku))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForAllOtherMembers(opts => opts.Ignore());

            CreateMap<EditProductRequest, Product>()                
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForAllOtherMembers(opts => opts.Ignore());
        }

        #endregion
    }
}
