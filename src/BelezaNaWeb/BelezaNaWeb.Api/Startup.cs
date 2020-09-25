using Serilog;
using MediatR;
using System.Reflection;
using BelezaNaWeb.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using BelezaNaWeb.Framework.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BelezaNaWeb.Api
{
    public class Startup
    {
        #region Public Properties

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostingEnvironment { get; }

        #endregion

        #region Constructors

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnviroment)
        {
            Configuration = configuration;
            WebHostingEnvironment = webHostEnviroment;
        }

        #endregion

        #region Public Methods

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(Configuration)
                .AddSingleton(WebHostingEnvironment);
            
            services
                .AddCors()
                .AddControllers();

            services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddFrameworkDependencies(enableSensitiveData: WebHostingEnvironment.IsDevelopment());

            services
                .ConfigureCulture()
                .ConfigureCaching()
                .ConfigureCompression()
                .ConfigureMvc()
                .ConfigureAutoMapper()
                .ConfigureApiVersion()                                            
                .ConfigureSwagger();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseHttpsRedirection()
                .UseResponseCompression()
                .UseStaticFilesConfiguration()
                .UseSerilogRequestLogging()
                .UseMiddlewareConfiguration()
                .UseStatusCodePagesConfiguration()
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Content-Disposition")
                )
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(options =>
                {
                    options.MapControllers();
                })
                .UseCultureConfiguration()
                .UseResponseCaching()
                .UseSwaggerConfiguration();
        }

        #endregion
    }
}
