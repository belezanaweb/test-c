using AutoMapper;

namespace Boticario.BelezaWeb.Application.AutoMapper
{
	public class AutoMapperConfiguration
	{
		public static MapperConfiguration RegisterMappings() =>
			new MapperConfiguration(cfg =>
				cfg.AddProfile(new AutoMapperProfile()));
	}
}
