using BrunoTragl.BelezaNaWeb.Web.WebApi;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace BrunoTragl.BelezaNaWeb.Tests.WebApi.Base
{
    public abstract class WebApiBase
    {
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
                             .SetBasePath("")
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
            var userSettings = _configuration.GetSection("UserSettings");
            object credentials = new
            {
                user = userSettings.GetSection("User").Value,
                password = userSettings.GetSection("Password").Value
            };

            var response = _httpClient.PostAsync("/auth", CreateContent(credentials)).Result;
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TokenModel>(response.Content.ReadAsStringAsync().Result);

            return null;
        }

        protected virtual RequestBuilder CreateRequestBuilder(string address, string method, string token, StringContent content = null)
        {
            var requestBuilder = _testServer.CreateRequest(address).And((config) =>
            {
                config.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                config.Method = new HttpMethod(method);
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
    }
}
