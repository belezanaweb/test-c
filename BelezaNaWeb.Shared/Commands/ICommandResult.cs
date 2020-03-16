using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Shared.Commands
{
    public interface ICommandResult
    {
        bool success { get; set; }
        string message { get; set; }
        object data { get; set; }
    }
}
