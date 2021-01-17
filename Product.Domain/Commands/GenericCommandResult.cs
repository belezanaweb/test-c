using Product.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {        
        public GenericCommandResult() { }

        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public bool Success { get; set; } 
        public string Message { get; set; }
        public object Data { get; set; }

    }
}
