using Microsoft.Extensions.Configuration;
using System;

namespace BelezaNaWebAPI
{
    public static class Settings
    {
        public static string GetConnectionString(string name) => Environment.ExpandEnvironmentVariables(Startup.Configuration.GetConnectionString(name));
        public static string Get(string name) => Environment.ExpandEnvironmentVariables(Startup.Configuration[name]);
        public static string TrimUrl(string url) => url.Trim(' ', '/');
        public static string JoinPath(this string src, string path) => $"{TrimUrl(src)}/{TrimUrl(path)}";

        public static class Services
        {
            public static string CoolService { get; } = TrimUrl(Get("CoolServiceEndpoint")); 
            public static string AnotherService { get; } = TrimUrl(Get("AnotherServiceEndpoint"));
        }
    }
}
