using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TestC.ExceptionHandler;
using TestC.Models;
using TestC.Services;
using TestC.Repositories;

namespace TestC
{
    [ExcludeFromCodeCoverageAttribute]
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
            //services.AddControllers();
            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));

            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IBaseRepository<Product>, ProductRepository>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext => 
                {
                    var listErrors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .Select(e => string.Format("{0} - {1}", e.Key, e.Value.Errors.First().ErrorMessage))
                        .ToArray();
            
                    return new BadRequestObjectResult(new {
                        statusCode = 400,
                        messages = listErrors
                    });
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseExceptionHandler("/error");
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    } 
}
