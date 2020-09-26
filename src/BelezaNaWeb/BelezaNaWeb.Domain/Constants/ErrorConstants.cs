using System.Net;

namespace BelezaNaWeb.Domain.Constants
{
    public static class ErrorConstants
    {
        #region Generic Constants
        
        public static class Forbidden
        {
            public const string Name = "FORBIDDEN";
            public const string Message = "The server declined a request.";
        }

        public static class Unauthorized
        {
            public const string Name = "UNAUTHORIZED";
            public const string Message = "The requested resource requires authentication.";
        }

        public static class NotFound
        {
            public const string Name = "NOT_FOUND";
            public const string Message = "The requested resource was not found on the server.";
        }

        public static class BadRequest
        {
            public const string Name = "BAD_REQUEST";
            public const string Message = "The server was unable to understand the request.";
        }

        public static class MethodNotAllowed
        {
            public const string Name = "METHOD_NOT_ALLOWED";
            public const string Message = "The request method is not allowed for the requested resource.";
        }

        public static class RequestTimeout
        {
            public const string Name = "REQUEST_TIMEOUT";
            public const string Message = "The server timed out the request.";
        }

        public static class InternalServerError
        {
            public const string Name = "INTERNAL_SERVER_ERROR";
            public const string Message = "A generic server error has occurred.";
        }

        #endregion

        #region Custom Constants

        public static class ProductNotFound
        {
            public const int Code = (int)HttpStatusCode.NotFound;
            public const string Name = "PRODUCT_NOT_FOUND";
            public const string Message = "Product not found.";
        }

        public static class ProductAlreadyExists
        {
            public const int Code = (int)HttpStatusCode.BadRequest;
            public const string Name = "PRODUCT_ALREADY_EXISTS";
            public const string Message = "This product is already exists.";
        }

        #endregion
    }
}
