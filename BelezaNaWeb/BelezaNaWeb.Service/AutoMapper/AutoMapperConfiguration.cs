using AutoMapper;

namespace BelezaNaWeb.Service.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(c =>
            {
                c.AddProfile(new DomainToViewModelMappingProfile());
                c.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
