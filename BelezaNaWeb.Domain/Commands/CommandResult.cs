using BelezaNaWeb.Shared.Commands;

namespace BelezaNaWeb.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message, object data) {
            this.success = success;
            this.message = message;
            this.data = data;
        }

        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
