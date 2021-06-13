using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TesteBoticario.Core.Services;
using TesteBoticario.Core.Services.Interfaces;
using TesteBoticario.Storage;
using TesteBoticario.Storage.Interfaces;

namespace TesteBoticario.Api
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
            services.AddControllers();

            var assembly = AppDomain.CurrentDomain.Load("TesteBoticario.Core");

            #region MediatR
            services.AddMediatR(assembly);
            #endregion

            #region AutoMapper
            services.AddAutoMapper(assembly);
            #endregion

            #region Service
            services.AddScoped<IProductService, ProductService>();
            #endregion

            #region Memory
            services.AddMemoryCache();
            services.AddScoped<IProductCache, ProductCache>();
            #endregion
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
