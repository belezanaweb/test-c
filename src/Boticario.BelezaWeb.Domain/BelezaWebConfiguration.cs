using Microsoft.Extensions.Configuration;

namespace Boticario.BelezaWeb.Domain
{
	public static class BelezaWebConfiguration
	{
		public static void Configure(IConfiguration configuration)
		{
			AddConfigurations(configuration);
		}

		public static void AddConfigurations(IConfiguration configuration)
		{
			ConnectionStrings = new ConnectionStringsConfiguration
			{
				PrincipalConnection = configuration
					?.GetSection(
						$"{ConnectionStringsConfiguration.ConnectionStrings}:{nameof(ConnectionStringsConfiguration.PrincipalConnection)}")
					?.Value
			};
		}

		public static ConnectionStringsConfiguration ConnectionStrings;
	}

	public class ConnectionStringsConfiguration
	{
		public const string ConnectionStrings = "ConnectionStrings";
		public string PrincipalConnection { get; set; }
	}
}
