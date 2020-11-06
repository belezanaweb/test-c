using Boticario.BelezaWeb.Domain;
using Boticario.BelezaWeb.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System.IO.Compression;
using System.Linq;

namespace Boticario.BelezaWeb.Api
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
			BelezaWebConfiguration.Configure(Configuration);
			services.AddControllers();

			services.AddResponseCompression(options =>
			{
				options.EnableForHttps = true;
				options.Providers.Add<GzipCompressionProvider>();
				options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
				{
					"application/json",
					"text/json",
					"image/png",
					"image/x-icon",
					"image/svg+xml",
					"application/x-font-ttf"
				});
			});

			services.Configure<GzipCompressionProviderOptions>(opt => opt.Level = CompressionLevel.Optimal);

			services.InjectCashBackDependencies();
			services.InjectAutoMapper();
			services.InjectSwagger();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.Use(async (context, next) =>
			{
				context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
				context.Response.Headers.Add("X-Content-Type-Options", "NOSNIFF");
				context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
				await next();
			});

			app.UseRouting();
			app.UseResponseBuffering();
			app.UseAuthorization();
			app.UseStaticFiles(new StaticFileOptions
			{
				OnPrepareResponse = ctx => { ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=86400"; }
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			app.UseSwagger();
			app.UseSwaggerUI(options =>
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "Beleza na Web Services"));
		}
	}
}
