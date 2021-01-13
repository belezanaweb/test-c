using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using Produto.Domain.Notifications;
using Produto.Domain.Repositories;
using Produto.Domain.Services;
using Produto.Infra.Contexts;
using Produto.Infra.Repository;
using Produto.Service.Services;
using System;
using System.IO;
using System.Reflection;

namespace Produto.Application
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Hosting.IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                               .SetBasePath(env.ContentRootPath)
                               .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                               .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true)
                               .AddEnvironmentVariables();
            Configuration = builder.Build();

        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BackEnd Test C",
                    Contact = new OpenApiContact() { Name = "Ana Paula de Souza", Email = "anasouza.0309@gmail.com" }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<ProductDBContext>(options =>
            {
                options.UseInMemoryDatabase("produto-api-in-memory");
            });

            services.AddScoped<IProdutoRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<NotificationContext>();

            services.AddMvc(options => options.Filters.Add<NotificationFilter>());
   




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackEnd Test C V1");
            });

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
