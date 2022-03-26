namespace ProductApi.Models
{
    public class ValidationException : Exception
    {
        public ValidationException(string validationError)
        {
            ValidationMessage = validationError;
        }

        public string ValidationMessage { get; set; }
    }
}