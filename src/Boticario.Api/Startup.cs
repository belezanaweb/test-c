using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text.Json;

namespace Boticario.Api
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
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true; 
                o.DefaultApiVersion = new ApiVersion(1,0);
                o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o);
            } );

            services.AddControllers();

            services.AddSwagger();

            services.AddApiVersioning();


            services.AddAutoMapper(Assembly.Load("Boticario.Domain"));

            //Extension
            services.AddRepositoriesAndServices();

            services.AddHealthChecks();

            //Se tiver uma connectionString do ApplicationInsigths, colar em appsetings.Development.json APPINSIGHTS: {CONNECTIONSTRING: ""}            
            //Extension
            services.AddTelemetry(Configuration["APPINSIGHTS_CONNECTIONSTRING"]);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Boticario.Api v1");
                    
                    //c.EnableFilter();


                }); 
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseHealthChecks("/status-text");
            app.UseHealthChecks("/status-json",
                new HealthCheckOptions()
                {
                    ResponseWriter = async (context, report) =>
                    {
                        var result = JsonSerializer.Serialize(new
                        {
                            currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            statusApplication = report.Status.ToString(),
                        });

                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        await context.Response.WriteAsync(result);
                    }
                });


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });




        }
    }
}
