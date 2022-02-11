using MediatR;
using BelezaWeb.Domain.Models;
using BelezaWeb.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using BelezaWeb.Infra.Configurations;
using BelezaWeb.Infra.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BelezaWeb.Infra.ExceptionHandler.Extension;
using BelezaWeb.Infra.Cross.Configurations;

namespace BelezaWeb.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerSetup();
            services.AddMediatR();
            services.AddScoped<IRepository<Product>, Repository>();
            services.AddControllers();
            services.AutoMapperConfig();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            
            app.UseGlobalExceptionErrorHandler();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers();});
            app.UseSwaggerSetup();
        }
    }
}
