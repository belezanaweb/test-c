using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BelezaNaWeb.Domain.Constants;

namespace BelezaNaWeb.Domain.Dtos
{
    [Serializable]
    [DataContract]
    public sealed class ErrorDto
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

        public ErrorDto(string name, string message, int statusCode)
            : this(name, message, statusCode, details: null)
        { }

        public ErrorDto(string name, string message, int statusCode, IEnumerable<ErrorFieldDto> details)
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

        public static ErrorDto DefaultUnauthorizedResponse()
            => new ErrorDto(ErrorConstants.Unauthorized.Name, ErrorConstants.Unauthorized.Message, (int)HttpStatusCode.Unauthorized);

        public static ErrorDto DefaultForbiddenResponse()
            => new ErrorDto(ErrorConstants.Forbidden.Name, ErrorConstants.Forbidden.Message, (int)HttpStatusCode.Forbidden);

        public static ErrorDto DefaultNotFoundResponse()
            => new ErrorDto(ErrorConstants.NotFound.Name, ErrorConstants.NotFound.Message, (int)HttpStatusCode.NotFound);

        public static ErrorDto DefaultBadRequestResponse()
            => new ErrorDto(ErrorConstants.BadRequest.Name, ErrorConstants.BadRequest.Message, (int)HttpStatusCode.BadRequest);

        public static ErrorDto DefaultMethodNotAllowedResponse()
            => new ErrorDto(ErrorConstants.MethodNotAllowed.Name, ErrorConstants.MethodNotAllowed.Message, (int)HttpStatusCode.MethodNotAllowed);

        public static ErrorDto DefaultRequestTimeoutResponse()
            => new ErrorDto(ErrorConstants.RequestTimeout.Name, ErrorConstants.RequestTimeout.Message, (int)HttpStatusCode.RequestTimeout);

        public static ErrorDto DefaultInternalServerErrorResponse()
            => new ErrorDto(ErrorConstants.InternalServerError.Name, ErrorConstants.InternalServerError.Message, (int)HttpStatusCode.InternalServerError);

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
