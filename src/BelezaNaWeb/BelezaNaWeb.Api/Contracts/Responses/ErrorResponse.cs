using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BelezaNaWeb.Domain.Constants;

namespace BelezaNaWeb.Api.Contracts.Responses
{
    [Serializable]
    [DataContract]
    public sealed class ErrorResponse
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
        public IEnumerable<ErrorField> Details { get; set; }

        #endregion

        #region Constructors

        public ErrorResponse(string name, string message, int statusCode)
            : this(name, message, statusCode, details: null)
        { }

        public ErrorResponse(string name, string message, int statusCode, IEnumerable<ErrorField> details)
        {
            Name = name;
            Message = message;
            StatusCode = statusCode;
            Timestamp = DateTime.Now;
            Id = Guid.NewGuid().ToString();
            Details = details ?? new List<ErrorField>();
        }

        #endregion

        #region Public Static Methods

        public static ErrorResponse DefaultUnauthorizedResponse()
            => new ErrorResponse(ErrorConstants.Unauthorized.Name, ErrorConstants.Unauthorized.Message, (int)HttpStatusCode.Unauthorized);

        public static ErrorResponse DefaultForbiddenResponse()
            => new ErrorResponse(ErrorConstants.Forbidden.Name, ErrorConstants.Forbidden.Message, (int)HttpStatusCode.Forbidden);

        public static ErrorResponse DefaultNotFoundResponse()
            => new ErrorResponse(ErrorConstants.NotFound.Name, ErrorConstants.NotFound.Message, (int)HttpStatusCode.NotFound);

        public static ErrorResponse DefaultBadRequestResponse()
            => new ErrorResponse(ErrorConstants.BadRequest.Name, ErrorConstants.BadRequest.Message, (int)HttpStatusCode.BadRequest);

        public static ErrorResponse DefaultMethodNotAllowedResponse()
            => new ErrorResponse(ErrorConstants.MethodNotAllowed.Name, ErrorConstants.MethodNotAllowed.Message, (int)HttpStatusCode.MethodNotAllowed);

        public static ErrorResponse DefaultRequestTimeoutResponse()
            => new ErrorResponse(ErrorConstants.RequestTimeout.Name, ErrorConstants.RequestTimeout.Message, (int)HttpStatusCode.RequestTimeout);

        public static ErrorResponse DefaultInternalServerErrorResponse()
            => new ErrorResponse(ErrorConstants.InternalServerError.Name, ErrorConstants.InternalServerError.Message, (int)HttpStatusCode.InternalServerError);

        #endregion
    }

    [Serializable]
    [DataContract]
    public sealed class ErrorField
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

        public ErrorField(string field, string value)
            : this(field, value, issue: null, location: null)
        { }

        public ErrorField(string field, string value, string issue, string location)
        {
            Field = field;
            Value = value;
            Issue = issue;
            Location = location;
        }

        #endregion
    }
}
