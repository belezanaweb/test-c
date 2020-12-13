using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Text;

namespace Desafio.Domain.Command
{
    public abstract class Command
    {
        public ValidationResult ValidationResult { get;  set; }

        public abstract bool IsValid();
    }
}
