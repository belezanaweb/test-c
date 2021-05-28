using System.Collections.Generic;

namespace Inventory.Domain.Commands
{
    public abstract class ValidatableCommand : NetHacksPack.Core.Command
    {
        protected readonly Dictionary<string, string> notifications = new Dictionary<string, string>();
        public IEnumerable<KeyValuePair<string, string>> Notifications { get => notifications; }

    }
}
