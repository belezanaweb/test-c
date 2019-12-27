using BelezaNaNet.Api.Context;
using BelezaNaNet.Api.Models;
using BelezaNaNet.Api.ValueObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BelezaNaNet.Api
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
            //services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("BelezaNaNetDb"));
            services.AddDbContext<ApiContext, ApiContext>(opt => opt.UseInMemoryDatabase("BelezaNaNetDb"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApiContext>();
                AddInitialData(context);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void AddInitialData(ApiContext context)
        {
            var firstWarehouse = new Warehouse("SP", 12, "ECOMMERCE");
            var secondWarehouse = new Warehouse("MOEMA", 3, "PHYSICAL_STORE");
            var warehouses = new List<Warehouse>() { firstWarehouse, secondWarehouse };

            var inventory = new Inventory(warehouses);

            var product = new Product(43264, "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g", inventory);
            
            context.Products.Add(product);
            context.SaveChanges();
        }
    }
}
