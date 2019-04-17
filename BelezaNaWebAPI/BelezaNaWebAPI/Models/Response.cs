using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BelezaNaWebAPI.Models
{
    public class Response
    {
        public JArray MessageResponse { get; set; }
        public string StatusMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string MessageError { get; set; }
    }
}