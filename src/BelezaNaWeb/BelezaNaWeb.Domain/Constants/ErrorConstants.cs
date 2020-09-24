namespace BelezaNaWeb.Domain.Constants
{
    public static class ErrorConstants
    {
        #region Public Constants

        public static class Forbidden
        {
            public const string Name = "FORBIDDEN";
            public const string Message = "O servidor recusou a solicitação.";
        }

        public static class Unauthorized
        {
            public const string Name = "UNAUTHORIZED";
            public const string Message = "O recurso solicitado requer autenticação.";
        }

        public static class NotFound
        {
            public const string Name = "NOT_FOUND";
            public const string Message = "O recurso solicitado não foi localizado no servidor.";
        }

        public static class BadRequest
        {
            public const string Name = "BAD_REQUEST";
            public const string Message = "O servidor não conseguiu entender a solicitação.";
        }

        public static class MethodNotAllowed
        {
            public const string Name = "METHOD_NOT_ALLOWED";
            public const string Message = "O método da solicitação não é permitido para o recurso solicitado.";
        }

        public static class RequestTimeout
        {
            public const string Name = "REQUEST_TIMEOUT";
            public const string Message = "O servidor atingiu o tempo limite da solicitação.";
        }

        public static class InternalServerError
        {
            public const string Name = "INTERNAL_SERVER_ERROR";
            public const string Message = "Ocorreu um erro genérico no servidor.";
        }

        #endregion
    }
}
