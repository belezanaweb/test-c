using AutoMapper;

namespace BelezaNaWebAPI.Profiles
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<Model.Product, Dto.Product>();
            CreateMap<Dto.UpdateProduct, Model.Product>();
            CreateMap<Model.Product, Model.Product>();
        }
    }
}
