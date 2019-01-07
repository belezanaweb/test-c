using AutoMapper;
using BelezaNaWeb.Application.Products.Interfaces;
using BelezaNaWeb.Application.Products.Services;
using BelezaNaWeb.Domain.Products.Interfaces;
using BelezaNaWeb.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;

namespace BelezaNaWebTest
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IProductRepository, MemoryProductRepository>();
            services.AddSingleton<IProductService, ProductService>();

            services.AddAutoMapper();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info 
                { 
                    Title = "Beleza na Web", 
                    Version = "v1",
                    Description = "Prova para processo seletivo - Beleza na Web",
                    Contact = new Contact
                    {
                        Name = "Elton Carreiro",
                        Email = "eltoonx3@gmail.com",
                        Url = "https://github.com/EltonCarreiro"
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Beleza na Web");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
