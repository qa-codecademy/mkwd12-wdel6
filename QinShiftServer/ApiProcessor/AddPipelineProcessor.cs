using ServerTwo.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProcessor
{
    public class AddPipelineProcessor : IPipelineProcessor
    {
        public bool CanProcess(Request request)
        {
            return request.Path.StartsWith("/add");
        }

        public BaseResponse Process(Request request)
        {
            Console.WriteLine(string.Join(" -- ", request.Path.Split("/")));
            var result = request.Path.Split("/") switch
            {
                [_, "add", var first, var second] => GetResponse(first, second),
                _ => throw new QinshiftServerException("Invalid parameters")
            };
            return result;
        }

        private Response GetResponse(string first, string second)
        {
            if (!int.TryParse(first, out var firstNumber) || !int.TryParse(second, out var secondNumber))
            {
                throw new QinshiftServerException("Invalid parameters");
            }

            var result = firstNumber + secondNumber;
            var bodyBuilder = new StringBuilder();
            bodyBuilder.AppendLine("{");
            bodyBuilder.AppendLine($"  \"first\": {firstNumber},");
            bodyBuilder.AppendLine($"  \"second\": {secondNumber},");
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
