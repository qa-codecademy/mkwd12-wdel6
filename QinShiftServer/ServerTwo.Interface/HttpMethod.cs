using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTwo.Interface
{
    public struct HttpMethod: IEquatable<HttpMethod>
    {
        public string MethodName { get; private set; } = string.Empty;


        private HttpMethod(string methodName)
        {
            MethodName = methodName;
        }

        private static bool IsNameValid(string methodName)
        {
            return true;
        }

        #region FromCode
        public static HttpMethod FromName(string methodName)
        {
            if (!IsNameValid(methodName))
            {
                throw new ArgumentOutOfRangeException(nameof(methodName), $"Method name must be valid (value is {methodName})");
            }

            if (_lookup.TryGetValue(methodName.ToUpper(), out var HttpMethod))
            {
                return HttpMethod;
            }
            // If the method name is different, return a new http method
            return new HttpMethod(methodName);
        }

        private static HttpMethod FromCodeImpl(string methodName)
        {
            return new HttpMethod(methodName);
        }

        public static (bool Success, HttpMethod HttpMethod) TryFromName(string methodName)
        {
            if (!IsNameValid(methodName))
            {
                return (false, default);
            }
            return (true, FromName(methodName));
        }

        public static bool TryFromName(string methodName, out HttpMethod HttpMethod)
        {
            if (!IsNameValid(methodName))
            {
                HttpMethod = default;
                return false;
            }
            HttpMethod = FromName(methodName);
            return true;
        }
        #endregion

        #region Constants
        public static HttpMethod Get { get; } = new HttpMethod("GET");
        public static HttpMethod Post { get; } = new HttpMethod("POST");
        public static HttpMethod Put { get; } = new HttpMethod("PUT");
        public static HttpMethod Patch { get; } = new HttpMethod("PATCH");
        public static HttpMethod Delete { get; } = new HttpMethod("DELETE");
        public static HttpMethod Head { get; } = new HttpMethod("HEAD");
        public static HttpMethod Options { get; } = new HttpMethod("OPTIONS");

        private static readonly Dictionary<string, HttpMethod> _lookup = new()
        {
            { "GET", Get },
            { "POST", Post },
            { "PUT", Put },
            { "PATCH", Patch },
            { "DELETE", Delete },
            { "HEAD", Head },
            { "OPTIONS", Options }
        };
        #endregion

        public override string ToString()
        {
            return MethodName.ToUpperInvariant();
        }

        public bool Equals(HttpMethod other)
        {
            return MethodName.Equals(other.MethodName, StringComparison.InvariantCultureIgnoreCase);
        }

        #region Implicit Operators
        public static implicit operator string(HttpMethod HttpMethod)
        {
            return HttpMethod.MethodName;
        }

        public static implicit operator HttpMethod(string methodName)
        {
            return FromName(methodName);
        }
        #endregion
    }
}
