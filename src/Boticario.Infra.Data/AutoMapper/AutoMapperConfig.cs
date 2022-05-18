using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Infra.Data.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ProfileBase));
        }
    }
}
