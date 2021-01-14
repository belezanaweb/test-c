using AutoMapper;
using BelezaNaWeb.Application;
using BelezaNaWeb.Application.AutoMapper;
using BelezaNaWeb.Application.Interfaces;
using BelezaNaWeb.Domain.Interfaces.Repository;
using BelezaNaWeb.Domain.Interfaces.Service;
using BelezaNaWeb.Domain.Services;
using BelezaNaWeb.Infra.Data.Context;
using BelezaNaWeb.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BelezaNaWeb.Services.API
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
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("Beleza"));

            //Configurações AUTOMAPPER
            services.AddAutoMapper(typeof(MappingProfile));


            //Configurações SWAGGER
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "BelezaNaWeb Doc API",
                    Description = "Documentação da API BelezaNaWeb"
                });
            });

            services.AddControllers();

            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IInventarioService, InventarioService>();
            services.AddScoped<IInventarioRepository, InventarioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "DocAPI");
                s.RoutePrefix = string.Empty;
            });

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
