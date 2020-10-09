using BackendTest.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Reflection;

namespace TestBackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object PlatformServices { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });

            services.AddDbContext<BackEndTestContext>(opt => opt.UseInMemoryDatabase("WebApiBackEndTestContext"));
            services.AddControllers();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("WebApiBackEndTest", new OpenApiInfo() { Title = "WebApiBackEndTest", Version = "V1" }); ;
            });
        
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/WebApiBackEndTest/swagger.json", "WebApiBackEndTest"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                         name: "default",
                         pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllers();
            });
        }
    }
}
