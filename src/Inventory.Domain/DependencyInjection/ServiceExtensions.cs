using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Domain.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCommandsAndEventsHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<Commands.CreateProductCommand, bool>, Handlers.ProductSaga>();
            services.AddTransient<IRequestHandler<Commands.UpdateProductCommand, bool>, Handlers.ProductSaga>();
            services.AddTransient<IRequestHandler<Commands.RemoveProductCommand, bool>, Handlers.ProductSaga>();
            
            services.AddScoped<Handlers.Notifiable<Events.DomainErrorRaised>>();
            services.AddScoped<Core.Notification.INotifiable<Events.DomainErrorRaised>>((service) => service.GetRequiredService<Handlers.Notifiable<Events.DomainErrorRaised>>());
            services.AddScoped<INotificationHandler<Events.DomainErrorRaised>>((service) => service.GetRequiredService<Handlers.Notifiable<Events.DomainErrorRaised>>());

            return services;
        }
    }
}
