namespace ServerTwo.Interface
{
    public class Request(HttpMethod method, string path, Headers headers, string body = "")
    {
        public HttpMethod Method { get; init; } = method;

        public string Path { get; init; } = path;

        public Headers Headers { get; init; } = headers;
        public string Body { get; init; } = body;
    }

    public class InvalidRequest(HttpMethod method, string path, Headers headers, string body = "") : Request(method, path, headers, body)
    {

        public static InvalidRequest InvalidRequestLine(string message)
        {
            return new InvalidRequest(HttpMethod.FromName("INVALID"), string.Empty, new Headers(), message);
        }

        public static InvalidRequest InvalidHeaderLine(string message)
        {
            return new InvalidRequest(HttpMethod.FromName("INVALID"), string.Empty, new Headers(), message);
        }
    }
}