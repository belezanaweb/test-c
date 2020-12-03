using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BrunoTragl.BelezaNaWeb.Tests.WebApi.Base
{
    public abstract class WebApiBase
    {
        protected readonly HttpClient _httpClient;

        public WebApiBase()
        {
            _httpClient = CreateServerAndClient();
        }

        protected virtual HttpClient CreateServerAndClient()
        {
            return new HttpClient();
        }
    }
}
