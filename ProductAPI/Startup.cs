using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using ProductAPI.Context;
using ProductAPI.Models;

namespace ProductAPI
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
            services.AddSwaggerGen(s => {

                s.SwaggerDoc("v1", new OpenApiInfo
                    {                        
                        Title = "Produtos Beleza Na Web",
                        Version = "v1",
                        Description = "Exemplo de API REST",
                    Contact = new OpenApiContact
                    {
                        Name = "Ivan Santos",
                        Email = "ivanilds@gmail.com"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();
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

            app.UseSwagger();

            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductAPI"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddTestData(ProductContext context)
        {
            var warehouse1 = new Warehouse()
            {
                Locality = "SP",
                Quantity = 12,
                Type = "ECOMMERCE"
            };

            var warehouse2 = new Warehouse()
            {
                Locality = "MOEMA",
                Quantity = 3,
                Type = "PHYSICAL_STORE"
            };

            var inventory = new Inventory()
            {
                Warehouses = new List<Warehouse>()
            };

            inventory.Warehouses.Add(warehouse1);
            inventory.Warehouses.Add(warehouse2);

            var testeProduto1 = new Models.Product
            {
                ProductId = 1,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Sku = 43264,
              //  Inventory = inventory
            };

            context.Products.Add(testeProduto1);

            context.SaveChanges();
        }
    }
}
