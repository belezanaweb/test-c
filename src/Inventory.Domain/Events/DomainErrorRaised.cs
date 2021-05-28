using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Events
{
    public class DomainErrorRaised : NetHacksPack.Core.ObjectEvent
    {
        public DomainErrorRaised(IEnumerable<KeyValuePair<string, string>> errors)
        {
            this.errors.AddRange(errors);
        }

        private readonly List<KeyValuePair<string, string>> errors = new List<KeyValuePair<string, string>>();

        public IEnumerable<KeyValuePair<string, string>> Errors { get => errors; }
    }
}
