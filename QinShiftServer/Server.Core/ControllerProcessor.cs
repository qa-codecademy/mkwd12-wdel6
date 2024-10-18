using ServerTwo.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            return name.Substring(0, cindex);
        }

        private List<string> GetMethodNames()
        {
            return Controller
                .GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Select(m => m.Name)
                .ToList();
        }

        private List<Route> GetControllerRoutes()
        {
            var name = GetControllerName();
            var methods = GetMethodNames();

            return methods
                .Select(m => new Route($"{name}/{m}"))
                .ToList();
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
            return routes.Any(r => r.Matches(request.Path));
        }

        public BaseResponse Process(Request request)
        {
            var requestParts = request.Path.Split("/");
            var methodName = requestParts[2];
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
