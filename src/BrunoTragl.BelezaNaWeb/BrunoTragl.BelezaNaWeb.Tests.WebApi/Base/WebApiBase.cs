using BrunoTragl.BelezaNaWeb.Tests.WebApi.Enumerable;
using BrunoTragl.BelezaNaWeb.Web.WebApi;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace BrunoTragl.BelezaNaWeb.Tests.WebApi.Base
{
    public abstract class WebApiBase
    {
        protected abstract string ApiAddressProduct { get; }
        protected readonly HttpClient _httpClient;
        protected TestServer _testServer;
        protected IConfiguration _configuration;

        public WebApiBase()
        {
            _httpClient = CreateServerAndClient();
        }

        protected virtual HttpClient CreateServerAndClient()
        {
            _configuration = new ConfigurationBuilder()
                             .SetBasePath(GetStartupDirectory())
                             .AddJsonFile("appsettings.json")
                             .Build();

            _testServer = new TestServer(new WebHostBuilder()
                                         .UseEnvironment("Development")
                                         .UseConfiguration(_configuration)
                                         .UseStartup<Startup>());
            return _testServer.CreateClient();
        }

        protected virtual TokenModel GetToken()
        {
            var userSetting = _configuration.GetSection("UserSetting");
            object credentials = new
            {
                user = userSetting.GetSection("User").Value,
                password = userSetting.GetSection("Password").Value
            };

            var response = _httpClient.PostAsync("/auth", CreateContent(credentials)).Result;
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TokenModel>(response.Content.ReadAsStringAsync().Result);

            return null;
        }

        protected virtual RequestBuilder CreateRequestBuilder(Method method, string token, StringContent content = null, string addressComplement = null)
        {
            string path = string.IsNullOrEmpty(addressComplement) ? ApiAddressProduct : $"{ApiAddressProduct}{addressComplement}";
            var requestBuilder = _testServer.CreateRequest(path).And((config) =>
            {
                config.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                config.Method = new HttpMethod(method.ToString());
                if (content != null)
                    config.Content = content;
            });

            return requestBuilder;
        }

        protected virtual StringContent CreateContent(object obj)
        {
            string objString = JsonConvert.SerializeObject(obj);
            return new StringContent(objString, Encoding.UTF8, "application/json");
        }

        private string GetStartupDirectory()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            basePath = basePath.Replace(@"\bin\Debug\netcoreapp2.2\", "").Replace("Tests", "Web");

            return basePath;
        }
    }
}
