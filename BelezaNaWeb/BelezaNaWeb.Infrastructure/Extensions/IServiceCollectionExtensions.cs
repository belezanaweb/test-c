using BelezaNaWeb.Infrastructure.Mediator;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace BelezaNaWeb.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddMediator(this IServiceCollection services, Assembly[] assemblies)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddMediatR(assemblies);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));

            AssemblyScanner.FindValidatorsInAssemblies(assemblies)
                .ForEach(v => services.AddScoped(v.InterfaceType, v.ValidatorType));
        }
    }
}
