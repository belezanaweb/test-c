using AutoMapper;
using Inventory.api.Configurations;
using Inventory.Domain.DependencyInjection;
using Inventory.Infrastructure.Database.DependencyInjection;
using Inventory.Infrastructure.Database.Extensions.InMemory.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetHacksPack.Core.Extensions.Events.DependencyInjection;
using System;
using System.Linq;

namespace Inventory.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var settings = Configuration.GetSection(nameof(Settings)).Get<Settings>();
            var assemblies = settings.Assemblies.Select(assembly => AppDomain.CurrentDomain.Load(assembly)).ToArray();

            services
                .AddObjectEventsAndMessagesHandler(typeof(object));
            services
                .AddCommandsAndEventsHandlers();
            
            services.AddQueryableAsRepository<Infrastructure.Database.Context.ApplicationContext>();
            services.AddEfStorage().AddInMemoryRepository("grupoblzdb");
            services.AddControllers();
            services.AddSwagger();
            services.AddQueries();
            services.AddAutoMapper(assemblies);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(t => t.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Inventory Api - v1"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
