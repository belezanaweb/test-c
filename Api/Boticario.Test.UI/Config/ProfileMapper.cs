using AutoMapper;
using Boticario.Test.Application.Entity;

namespace Boticario.Test.UI.Config
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            var map = CreateMap<Product, Product>();
            map.ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}