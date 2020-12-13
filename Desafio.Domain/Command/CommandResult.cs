using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Domain.Command
{

    public class CommandResult
    {
        private CommandResult()
        {
        }

        public static CommandResult Ok()
        {
            return new CommandResult { Status = CommandResultStatus.Ok };
        }
        
        public static CommandResult Warning(string message)
        {
            return new CommandResult { Status = CommandResultStatus.Warning, Message = message };
        }

        public static CommandResult Error(string message)
        {
            return new CommandResult { Status = CommandResultStatus.Error, Message = message };
        }


        public CommandResultStatus Status { get; private set; }
        public string Message { get; private set; }
    }
}
