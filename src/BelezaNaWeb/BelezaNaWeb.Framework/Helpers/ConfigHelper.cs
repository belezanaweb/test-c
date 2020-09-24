using System.IO;
using BelezaNaWeb.Framework.Extensions;
using Microsoft.Extensions.Configuration;

namespace BelezaNaWeb.Framework.Helpers
{
    public static class ConfigHelper
    {
        #region Private Static Fields

        private static readonly IConfiguration configuration = CreateBuilder();

        private static IConfiguration CreateBuilder()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        #endregion

        #region Static Constructors

        static ConfigHelper()
        { }

        #endregion

        #region Public Static Methods

        public static string Get(string name)
        {
            string appSettings = configuration[name];
            return appSettings;
        }

        public static bool TryGet<TOutput>(string name, out TOutput output)
        {
            output = default;

            var exists = configuration.GetSection(name).Exists();
            if (exists) output = configuration.GetSection(name).Get<TOutput>();

            return exists;
        }

        public static string TryGet(string name, string defaultValue)
        {
            string appSettings = configuration[name];
            return (!appSettings.IsNullOrEmpty() ? appSettings : defaultValue);
        }

        #endregion
    }
}
