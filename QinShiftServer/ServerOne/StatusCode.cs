using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerOne
{
    internal struct StatusCode
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
        public static StatusCode Continue => new StatusCode(100, "Continue");
        public static StatusCode SwitchingProtocols => new StatusCode(101, "Switching Protocols");
        public static StatusCode Processing { get; } = new StatusCode(102);
        public static StatusCode OK { get; } = new StatusCode(200, "OK");
        public static StatusCode Created => new StatusCode(201);
        public static StatusCode Accepted => new StatusCode(202);
        public static StatusCode NoContent => new StatusCode(204);
        public static StatusCode MovedPermanently => new StatusCode(301);
        public static StatusCode Found => new StatusCode(302);
        public static StatusCode SeeOther => new StatusCode(303);
        public static StatusCode NotModified => new StatusCode(304);
        public static StatusCode BadRequest => new StatusCode(400);
        public static StatusCode Unauthorized => new StatusCode(401);
        public static StatusCode Forbidden => new StatusCode(403);
        public static StatusCode NotFound => new StatusCode(404);
        public static StatusCode MethodNotAllowed => new StatusCode(405);
        public static StatusCode NotAcceptable => new StatusCode(406);
        public static StatusCode Conflict => new StatusCode(409);
        public static StatusCode Gone => new StatusCode(410);
        public static StatusCode ImATeapot => new StatusCode(418);
        public static StatusCode UnprocessableEntity => new StatusCode(422);
        public static StatusCode UnavailableForLegalReasons => new StatusCode(451);
        public static StatusCode InternalServerError => new StatusCode(500);
        public static StatusCode NotImplemented => new StatusCode(501);
        public static StatusCode ServiceUnavailable => new StatusCode(503);
        public static StatusCode HTTPVersionNotSupported => new StatusCode(505);

        private static Dictionary<int, StatusCode> _lookup = new Dictionary<int, StatusCode>
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
