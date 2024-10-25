using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServerTwo.Interface.Attributes
{
    public abstract class BaseMethodAttribute(string? endpointName) : Attribute
    {
        public string? EndpointName { get; set; } = endpointName;
    }

    public static class MethodResolver {
        public static (BaseMethodAttribute? attribute, HttpMethod method) ResolveAttribute(MethodInfo methodInfo)
        {
            var attributes = methodInfo.GetCustomAttributes<BaseMethodAttribute>();
            var result = attributes.FirstOrDefault();
            if (result is HttpGetAttribute)
            {
                return (result, HttpMethod.Get);
            }
            else if (result is HttpPostAttribute)
            {
                return (result, HttpMethod.Post);
            }
            else
            {
                return (null, HttpMethod.Get);
            }
        }
    }
}
