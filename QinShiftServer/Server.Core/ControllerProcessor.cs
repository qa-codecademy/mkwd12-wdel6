using ServerTwo.Interface;
using ServerTwo.Interface.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using HttpMethod = ServerTwo.Interface.HttpMethod;

namespace ServerTwo.Core
{
    internal class ControllerProcessor(IController controller) : IPipelineProcessor
    {
        public IController Controller { get; } = controller;

        private string GetControllerName()
        {
            var name = Controller.GetType().Name;
            var cindex = name.IndexOf("Controller");
            if (cindex == -1)
            {
                return name;
            }
            return name[..cindex];
        }

        private List<MethodInfo> GetMethods()
        {
            return Controller
                .GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .ToList();
        }

        private IEnumerable<Route> GetControllerRoutes()
        {
            var name = GetControllerName();
            var methods = GetMethods();

            foreach (var method in methods) {
                var (attribute, httpMethod) = MethodResolver.ResolveAttribute(method);
                if (string.IsNullOrEmpty(attribute?.EndpointName))
                {
                    yield return new Route($"{name}/{method.Name}", httpMethod, method.Name);
                    continue;
                }
                yield return new Route($"{name}/{attribute.EndpointName}", httpMethod, method.Name);
            }
        }


        public bool CanProcess(Request request) {
            /*
                /calculator/add/:one/:two
                /calculator/double/:one
             */

            /*
                /calculator/add
                /calculator/double
             */

            var routes = GetControllerRoutes();
            var result = routes.Any(r => r.Matches(request));
            return result;
        }

        public BaseResponse Process(Request request)
        {
            var requestParts = request.Path.Split("/");
            var endpointName = requestParts[2];

            var routes = GetControllerRoutes();
            var route = routes.First(r => r.Matches(request));
            if (route == null)
            {
                throw new QinshiftServerException("Route not found");
            }

            var methodName = route.ProcessorName;
            var methodInfo = Controller.GetType().GetMethod(methodName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (methodInfo == null)
            {
                throw new QinshiftServerException("Controller Method not found");
            }
            var parameters = methodInfo.GetParameters();
            // this assumes that the parameters are in the path, and ignores the query string
            if (parameters.Length != requestParts.Length - 3)
            {
                throw new QinshiftServerException($"Invalid parameters for method {methodName}, {parameters.Length} values required");
            }

            var values = new object[parameters.Length];

            for (int index = 0; index < parameters.Length; index++)
            {
                var parameter = parameters[index];
                var parameterType = parameter.ParameterType;
                var value = requestParts[index + 3];

                if (parameterType == typeof(int))
                {
                    if (!int.TryParse(value, out var intValue))
                    {
                        throw new QinshiftServerException($"Invalid value for parameter {parameter.Name}");
                    }
                    values[index] = intValue;
                    continue;
                }
                if (parameterType == typeof(string))
                {
                    // no validation needed
                    values[index] = value;
                    continue;
                }
                throw new QinshiftServerException($"Unsupported parameter type {parameterType.Name}");
            }

            // all the parameters are validated and converted, we can now call the method
            var result = methodInfo.Invoke(Controller, values);

            var bodyBuilder = new StringBuilder();
            bodyBuilder.AppendLine("{");
            bodyBuilder.AppendLine($"  \"result\": {result}");
            bodyBuilder.AppendLine("}");

            return new Response
            {
                StatusCode = StatusCode.OK,
                Body = bodyBuilder.ToString(),
                Headers = new Headers
                {
                    { "Content-Type", "application/json" }
                }
            };
        }
    }
}
