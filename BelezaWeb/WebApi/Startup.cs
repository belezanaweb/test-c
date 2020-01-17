using DataAccess.DatabaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;

namespace WebApi
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        #region Properties

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddControllersAsServices();

            //Add database in memory
            services.AddDbContext<BelezaWebContext>(options => options.UseInMemoryDatabase(databaseName: "BelezaWeb"));

            //Register all services for injection
            RegisterServices(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method for register injection for the services
        /// </summary>
        /// <param name="services"></param>
        private void RegisterServices(IServiceCollection services)
        {           
            services.AddScoped<IProductService, ProductService>();          
        }

        #endregion        
    }
}
