using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerOne
{
    internal struct StatusCode: IEquatable<StatusCode>
    {
        public int Code { get; private set; }

        private string _description = string.Empty;
        public string Description { 
            get => string.IsNullOrEmpty(_description) ? Code.ToString() : _description;
            private set => _description = value;
        }

        private StatusCode(int codeValue, string description = "")
        {
            Code = codeValue;
            Description = description;
        }

        private static bool IsCodeValid(int codeValue)
        {
            return codeValue >= 100 && codeValue <= 999;
        }

        #region FromCode
        public static StatusCode FromCode(int codeValue, string description = "")
        {
            if (!IsCodeValid(codeValue))
            {
                throw new ArgumentOutOfRangeException(nameof(codeValue), $"Code value must be between 0 and 999 (value is {codeValue})");
            }
            //return FromCodeImpl(codeValue);
            // return new StatusCode(codeValue) { Description = description };

            if (_lookup.TryGetValue(codeValue, out var statusCode))
            {
                // If the description is empty, return the existing status code
                if (string.IsNullOrEmpty(description))
                {
                    return statusCode;
                }
                // If the description is the same, return the existing status code
                if (statusCode.Description == description)
                {
                    return statusCode;
                }
            }
            // If the description or code are different, return a new status code
            return new StatusCode(codeValue, description);
        }

        private static StatusCode FromCodeImpl(int codeValue)
        {
            return new StatusCode(codeValue);
        }

        public static (bool Success, StatusCode statusCode) TryFromCode(int codeValue, string description)
        {
            if (!IsCodeValid(codeValue))
            {
                return (false, default);
            }
            return (true, FromCode(codeValue, description));
        }

        public static bool TryFromCode(int codeValue, string description, out StatusCode statusCode)
        {
            if (!IsCodeValid(codeValue))
            {
                statusCode = default;
                return false;
            }
            statusCode = FromCode(codeValue, description);
            return true;
        }
        #endregion

        #region Constants
        public static StatusCode Continue { get; } = new StatusCode(100, "Continue");
        public static StatusCode SwitchingProtocols { get; } = new StatusCode(101, "Switching Protocols");
        public static StatusCode Processing { get; } = new StatusCode(102, "Processing");
        public static StatusCode OK { get; } = new StatusCode(200, "OK");
        public static StatusCode Created { get; } = new StatusCode(201, "Created");
        public static StatusCode Accepted { get; } = new StatusCode(202, "Accepted");
        public static StatusCode NoContent { get; } = new StatusCode(204, "No Content");
        public static StatusCode MovedPermanently { get; } = new StatusCode(301, "Moved Permanently");
        public static StatusCode Found { get; } = new StatusCode(302, "Found");
        public static StatusCode SeeOther { get; } = new StatusCode(303, "See Other");
        public static StatusCode NotModified { get; } = new StatusCode(304, "Not Modified");
        public static StatusCode BadRequest { get; } = new StatusCode(400, "Bad Request");
        public static StatusCode Unauthorized { get; } = new StatusCode(401, "Unauthenticated");
        public static StatusCode Forbidden { get; } = new StatusCode(403, "Not Allowed");
        public static StatusCode NotFound { get; } = new StatusCode(404, "Not Found");
        public static StatusCode MethodNotAllowed { get; } = new StatusCode(405, "Method Not Allowed");
        public static StatusCode NotAcceptable { get; } = new StatusCode(406, "Not Acceptable");
        public static StatusCode Conflict { get; } = new StatusCode(409, "Conflict");
        public static StatusCode Gone { get; } = new StatusCode(410, "Gone");
        public static StatusCode ImATeapot { get; } = new StatusCode(418, "I'm a teapot");
        public static StatusCode UnprocessableEntity { get; } = new StatusCode(422, "Unprocessable Entity");
        public static StatusCode UnavailableForLegalReasons { get; } = new StatusCode(451, "Unavailable For Legal Reasons");
        public static StatusCode InternalServerError { get; } = new StatusCode(500, "Internal Server Error");
        public static StatusCode NotImplemented { get; } = new StatusCode(501, "Not Implemented");
        public static StatusCode ServiceUnavailable { get; } = new StatusCode(503, "Service Unavailable");
        public static StatusCode HTTPVersionNotSupported { get; } = new StatusCode(505, "HTTP Version Not Supported");

        private static readonly Dictionary<int, StatusCode> _lookup = new()
        {
            { 100, Continue },
            { 101, SwitchingProtocols },
            { 102, Processing },
            { 200, OK },
            { 201, Created },
            { 202, Accepted },
            { 204, NoContent },
            { 301, MovedPermanently },
            { 302, Found },
            { 303, SeeOther },
            { 304, NotModified },
            { 400, BadRequest },
            { 401, Unauthorized },
            { 403, Forbidden },
            { 404, NotFound },
            { 405, MethodNotAllowed },
            { 406, NotAcceptable },
            { 409, Conflict },
            { 410, Gone },
            { 418, ImATeapot },
            { 422, UnprocessableEntity },
            { 451, UnavailableForLegalReasons },
            { 500, InternalServerError },
            { 501, NotImplemented },
            { 503, ServiceUnavailable },
            { 505, HTTPVersionNotSupported },
        };
        #endregion

        public override string ToString()
        {
            return $"{Code} {Description}";
        }

        public bool Equals(StatusCode other)
        {
            return Code == other.Code;
        }

        #region Implicit Operators
        public static implicit operator int(StatusCode statusCode)
        {
            return statusCode.Code;
        }

        public static implicit operator StatusCode(int codeValue)
        {
            return FromCode(codeValue);
        }
        #endregion
    }
}
