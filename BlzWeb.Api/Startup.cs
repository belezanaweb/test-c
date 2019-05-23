using BlzWeb.Domain.StoreContext.Handlers;
using BlzWeb.Domain.StoreContext.Repositories;
using BlzWeb.Domain.StoreContext.Services;
using BlzWeb.Infra.DataContexts;
using BlzWeb.Infra.StoreContext.Repositories;
using BlzWeb.Infra.StoreContext.Services;
using BlzWeb.Shared;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace BlzWeb.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<BlzWebDataContext, BlzWebDataContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ProductHandler, ProductHandler>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Beleza na Web", Version = "v1" });
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Beleza na Web- V1");
            });

            app.UseElmahIo("923f4c946cc1435cb0ec665d6e7370b7", new Guid("e42a9995-df89-4d91-a625-ecc57d124004"));
        }
    }
}
