using GrupoBoticarioTeste.Business.Interfaces.Repositories;
using GrupoBoticarioTeste.Business.Interfaces.Services;
using GrupoBoticarioTeste.Business.Notificacoes;
using GrupoBoticarioTeste.Business.Services;
using GrupoBoticarioTeste.Infrastructure.Context;
using GrupoBoticarioTeste.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GrupoBoticarioTeste.API
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GrupoBoticarioTeste.API", Version = "v1" });
            });

            services.AddScoped<DataContext>();
            services.AddScoped<INotificadorService, Notificador>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GrupoBoticarioTeste.API v1"));
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
