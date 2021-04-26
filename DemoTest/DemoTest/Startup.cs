using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoTest.AppService.Application.Interface;
using DemoTest.AppService.Application.Produto;
using DemoTest.Domain.Repository.Interfaces;
using DemoTest.Domain.Service;
using DemoTest.Domain.Service.Interfaces;
using DemoTest.Infra.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using DemoTest.Infra;

namespace DemoTest
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
            // Configurando EF
            services.AddDbContext<ContextRepository>(opt => opt.UseInMemoryDatabase("DemoTest"));
            
            // Configurando Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "DemoTest Doc API",
                    Description = "Swagger com documentação para API"
                });
            });

            services.AddControllers();

            // Configurando Dependências
            services.AddScoped<IProdutoAppService, ProdutoAppService>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IInventarioService, InventarioService>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IInventarioRepository, InventarioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();

            // Configurando Swagger
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoTest.API");
                //s.RoutePrefix = string.Empty;
                s.DisplayRequestDuration();
                s.ShowExtensions();
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseRewriter(option);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
