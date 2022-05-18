using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belezanaweb.Core.Exceptions
{
    public class ValidatorException : Exception
    {
        public List<Exception> Exceptions { get; set; }

        public ValidatorException(ValidationResult validation) : this(validation, null)
        {
        }

        public ValidatorException(ValidationResult validation, Exception innerException) : base(null, innerException)
        {
            Exceptions = new List<Exception>();

            foreach (var error in validation.Errors)
            {
                Exceptions.Add(new Exception(error.ErrorMessage));
            }
        }
    }
}
