using ServerTwo.Interface;
using HttpMethod = ServerTwo.Interface.HttpMethod;

internal class RequestProcessor
{
    internal static Request ProcessRequest(string requestString)
    {
        var requestLines = requestString.Split("\r\n");

        var requestLineElements = requestLines[0].Split(" ");
        if (requestLineElements.Length != 3)
        {
            // this is an error, because the request line should have 3 elements
            return InvalidRequest.InvalidRequestLine("Request line does not have 3 elements");
        }
        var methodString = requestLineElements[0];
        var method = HttpMethod.FromName(methodString);

        var path = requestLineElements[1];

        var httpVersion = requestLineElements[2];
        if (httpVersion != "HTTP/1.1")
        {
            // this is an error, because we only support HTTP/1.1
            return InvalidRequest.InvalidRequestLine("Http version must be 1.1");
        }

        var headers = new Headers();
        for (var i = 1; i < requestLines.Length; i++)
        {
            var headerLine = requestLines[i];
            if (headerLine == "")
            {
                // we have reached the end of the headers
                break;
            }
            var headerElements = headerLine.Split(": ");
            if (headerElements.Length != 2)
            {
                // this is an error, because the header line should have 2 elements
                return InvalidRequest.InvalidHeaderLine($"Header line {headerLine} does not have 2 elements");
            }
            var headerName = headerElements[0];
            var headerValue = headerElements[1];
            headers.Add(headerName, headerValue);
        }

        var bodyStart = 1 + headers.Count + 1;
        var body = string.Join("\r\n", requestLines[bodyStart..(requestLines.Length-1)]);

        // here we can add body parsing, i.e. make the body into a JSON object

        return new Request(method, path, headers, body);
    }
}