using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BelezaNaWeb.Domain.Constants;

namespace BelezaNaWeb.Api.Dtos
{
    [Serializable]
    [DataContract]
    public sealed class ErrorResponseDto
    {
        #region Public Properties

        [DataMember]
        [JsonProperty("id")]
        public string Id { get; }

        [DataMember]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("message")]
        public string Message { get; set; }

        [DataMember]
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [DataMember]
        [JsonProperty("details")]
        public IEnumerable<ErrorFieldDto> Details { get; set; }

        #endregion

        #region Constructors

        public ErrorResponseDto(string name, string message, int statusCode)
            : this(name, message, statusCode, details: null)
        { }

        public ErrorResponseDto(string name, string message, int statusCode, IEnumerable<ErrorFieldDto> details)
        {
            Name = name;
            Message = message;
            StatusCode = statusCode;
            Timestamp = DateTime.Now;
            Id = Guid.NewGuid().ToString();
            Details = details ?? new List<ErrorFieldDto>();
        }

        #endregion

        #region Public Static Methods

        public static ErrorResponseDto DefaultUnauthorizedResponse()
            => new ErrorResponseDto(ErrorConstants.Unauthorized.Name, ErrorConstants.Unauthorized.Message, (int)HttpStatusCode.Unauthorized);

        public static ErrorResponseDto DefaultForbiddenResponse()
            => new ErrorResponseDto(ErrorConstants.Forbidden.Name, ErrorConstants.Forbidden.Message, (int)HttpStatusCode.Forbidden);

        public static ErrorResponseDto DefaultNotFoundResponse()
            => new ErrorResponseDto(ErrorConstants.NotFound.Name, ErrorConstants.NotFound.Message, (int)HttpStatusCode.NotFound);

        public static ErrorResponseDto DefaultBadRequestResponse()
            => new ErrorResponseDto(ErrorConstants.BadRequest.Name, ErrorConstants.BadRequest.Message, (int)HttpStatusCode.BadRequest);

        public static ErrorResponseDto DefaultMethodNotAllowedResponse()
            => new ErrorResponseDto(ErrorConstants.MethodNotAllowed.Name, ErrorConstants.MethodNotAllowed.Message, (int)HttpStatusCode.MethodNotAllowed);

        public static ErrorResponseDto DefaultRequestTimeoutResponse()
            => new ErrorResponseDto(ErrorConstants.RequestTimeout.Name, ErrorConstants.RequestTimeout.Message, (int)HttpStatusCode.RequestTimeout);

        public static ErrorResponseDto DefaultInternalServerErrorResponse()
            => new ErrorResponseDto(ErrorConstants.InternalServerError.Name, ErrorConstants.InternalServerError.Message, (int)HttpStatusCode.InternalServerError);

        #endregion
    }

    [Serializable]
    [DataContract]
    public sealed class ErrorFieldDto
    {
        #region Public Properties

        [DataMember]
        [JsonProperty("field")]
        public string Field { get; set; }

        [DataMember]
        [JsonProperty("value")]
        public string Value { get; set; }

        [DataMember]
        [JsonProperty("issue")]
        public string Issue { get; set; }

        [DataMember]
        [JsonProperty("location")]
        public string Location { get; set; }

        #endregion

        #region Constructors

        public ErrorFieldDto(string field, string value)
            : this(field, value, issue: null, location: null)
        { }

        public ErrorFieldDto(string field, string value, string issue, string location)
        {
            Field = field;
            Value = value;
            Issue = issue;
            Location = location;
        }

        #endregion
    }
}
