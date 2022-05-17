using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace webapi.application.Models
{
    public  class BaseResponse
    {
        [JsonIgnore]
        public bool IsValid { get { return string.IsNullOrWhiteSpace(ErrorMessage); } }
        [JsonIgnore]
        public string? ErrorMessage { get; set; }
    }
}
