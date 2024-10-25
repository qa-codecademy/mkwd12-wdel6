using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerTwo.Interface;

using HttpMethod = ServerTwo.Interface.HttpMethod;

namespace ServerTwo.Core
{
    internal class Route (string name, HttpMethod method, string processorName)
    {
        public string Name { get; } = name;

        public HttpMethod Method { get; } = method;

        public string ProcessorName { get; } = processorName;

        public bool Matches(Request request)
        {
            var pathMatch = 
                request.Path == $"/{Name}" ||
                request.Path.StartsWith($"/{Name}/", StringComparison.InvariantCultureIgnoreCase);

            var methodMatch = request.Method == Method;

            return pathMatch && methodMatch;
        }
    }
}
