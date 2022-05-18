using Boticario.Application.Interfaces;
using Boticario.Application.Services;
using Boticario.Core.Interfaces.Queries;
using Boticario.Core.Interfaces.Repositories;
using Boticario.Core.Interfaces.UoW;
using Microsoft.Extensions.DependencyInjection;
using Boticario.Infra.Data.AutoMapper;
using Boticario.Data.Context;
using Boticario.Infra.Data.Queries;
using Boticario.Data.UoW;
using Boticario.Infra.Data.Repositories;
using MediatR;
using Boticario.Core.Model.Commands.Base;
using Boticario.Core.Model.Commands.Produto;
using Boticario.Core.Handlers.Produto;

namespace Boticario.Infra.IoC
{
    public static class Bootstrapper
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<InserirProdutoCommand, CommandResult>, InserirProdutoHandler>();
            services.AddTransient<IRequestHandler<AtualizarProdutoCommand, CommandResult>, AtualizarProdutoHandler>();
            services.AddTransient<IRequestHandler<ExcluirProdutoCommand, CommandResult>, ExcluirProdutoHandler>();

            services.AddTransient<IProdutoService, ProdutoService>();

            services.AddTransient<IProdutoRepository, ProdutoRepository>();

            services.AddTransient<IProdutoQuery, ProdutoQuery>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<DefaultContext>();

            services.RegisterMappings();
        }
    }
}
