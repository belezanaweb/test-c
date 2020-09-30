using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BelezaWeb.Domain.Interfaces;
using BelezaWeb.Domain.Model;
using BelezaWeb.Infra.Configurations;
using BelezaWeb.Infra.Data.Repository;
using BelezaWeb.Infra.ExceptionHandler.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MediatR;
using BelezaWeb.Infra.CrossCutting.Configurations;

namespace BelezaWeb.API
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
            services.AddSwaggerSetup();
            services.AddMediatR();
            services.AddScoped<IRepository<Product>, Repository>();
            services.AddControllers();
            services.AutoMapperConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGlobalExceptionErrorHandler();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerSetup();
        }
    }
}
