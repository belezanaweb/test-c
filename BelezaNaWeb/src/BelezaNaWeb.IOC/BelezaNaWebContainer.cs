using AutoMapper;
using BelezaNaWeb.Data.Context;
using BelezaNaWeb.Data.Repository;
using BelezaNaWeb.Domain.Models.Repository;
using BelezaNaWeb.Service.AutoMapper;
using BelezaNaWeb.Service.Interfaces;
using BelezaNaWeb.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BelezaNaWeb.IOC
{
    public class BelezaNaWebContainer
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {

            #region Domain
            serviceCollection.AddScoped<IProdutoRepository, ProdutoRepository>();
            #endregion

            #region AppService
            serviceCollection.AddSingleton<IConfigurationProvider>(AutoMapperConfiguration.RegisterMappings());
            serviceCollection.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            serviceCollection.AddScoped<IProdutoService, ProdutoService>();
            #endregion

            #region Data
            serviceCollection.AddScoped<BelezaNaWebContext>();
            #endregion
        }
    }
}
