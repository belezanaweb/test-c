using AutoMapper;
using BelezaNaWeb.API.Dtos.Inventory;
using BelezaNaWeb.API.Dtos.Product;
using BelezaNaWeb.API.Dtos.WareHouse;
using BelezaNaWeb.API.Validators;
using BelezaNaWeb.Data;
using BelezaNaWeb.Data.Models;
using BelezaNaWeb.Data.Repositories;
using BelezaNaWeb.Data.Repositories.Interfaces;
using BelezaNaWeb.Services.Interfaces;
using BelezaNaWeb.Services.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BelezaNaWeb.API
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
            var connectionString = Configuration["ConnectionString"];
            services.AddControllers()
                .AddFluentValidation(fv => 
                { 
                    fv.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<UpdateProductValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<InventoryValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<WareHouseValidator>();
                });

            services.AddSwaggerGen();
            services.AddDbContext<BelezaNaWebDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDto, Product>().ReverseMap();
                cfg.CreateMap<CreateProductDto, Product>().ReverseMap();
                cfg.CreateMap<UpdateProductDto, Product>().ReverseMap();
                cfg.CreateMap<InventoryDto, Inventory>().ReverseMap();
                cfg.CreateMap<CreateInventoryDto, Inventory>().ReverseMap();
                cfg.CreateMap<WareHouseDto, WareHouse>().ReverseMap();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<BelezaNaWebDbContext>();
                context.Database.EnsureCreated();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
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
