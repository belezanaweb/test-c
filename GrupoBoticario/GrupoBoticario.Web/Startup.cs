using GrupoBoticario.DataAccess.Repositories.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GrupoBoticario.Domain.Extensions;
using GrupoBoticario.Application.Extensions;
using GrupoBoticario.DataAccess.Extensions;
using Microsoft.OpenApi.Models;
using System;

namespace GrupoBoticario.Web
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
            services.AddApplicationServices();
            
            services.AddDomainServices();

            services.AddRepositoryServices();
            services.AddDbContext<Context>(options => options.UseInMemoryDatabase("bwtemp"));
            services.AddControllers();
           

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api Beleza na Web",
                    Description = "Serviços de produtos",
                    TermsOfService = new Uri("https://www.belezanaweb.com.br/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Maxwbs",
                        Email = "maxwbs@gmail.com",
                        Url = new Uri("https://www.belezanaweb.com.br/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso",
                        Url = new Uri("https://www.belezanaweb.com.br/")
                    }
                });                
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Serviços da Beleza na Web versão V1.");
                c.RoutePrefix = string.Empty;
            });
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
