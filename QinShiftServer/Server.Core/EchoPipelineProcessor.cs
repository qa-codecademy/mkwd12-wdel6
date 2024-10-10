using ServerTwo.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTwo.Core
{
    internal class EchoPipelineProcessor : IPipelineProcessor
    {
        public bool CanProcess(Request request)
        {
            return true;
        }

        public Response Process(Request request)
        {
            var headersOutput = new StringBuilder(@"<div>
<h2>Headers:</h2>
<ul>
");
            foreach (var (name, value) in request.Headers)
            {
                headersOutput.AppendLine($"<li><strong>{name}</strong>: {value}</li>");
            }
            headersOutput.AppendLine("</ul></div>");

            var response = new Response
            {
                StatusCode = StatusCode.OK,
                Body = @$"<!DOCTYPE html>
        <html lang=""en"">
        <head>
            <meta charset=""UTF-8"">
            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
            <title>Qinshift Server Home Page</title>
        </head>
        <body>
            <h1>HI!</h1>

            <p>Qinshift Server is running!</p>

            <p>It's a simple server that can handle requests.</p>  
            <p>The method that was requested is: {request.Method}.</p>  
            <p>The Path that was requested is: {request.Path}.</p>  
            {headersOutput}
            {(string.IsNullOrWhiteSpace(request.Body) ? "" : $"<p>Body: {request.Body}</p>")}
        </body>
        </html>",
                Headers = new Headers
                {
                    { "Content-Type", "text/html" }
                }
            };
            return response;
        }
    }

}
