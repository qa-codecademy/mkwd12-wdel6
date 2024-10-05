
using ServerOne;

using System.Text;

internal static class OutputGenerator
{
    private const string HttpVersion = "HTTP/1.1";
    internal static ReadOnlySpan<byte> MakeResponse(Response response)
    {
        //var statusLine = $"{HttpVersion} {response.StatusCode.Code} {response.StatusCode.Description}\r\n";
        var statusLine = $"{HttpVersion} {response.StatusCode}\r\n";
        var headersBuilder = new StringBuilder();
        foreach (var (name, value) in response.Headers)
        {
            headersBuilder.AppendLine($"{name}: {value}");
        }
        var body = $"\r\n{response.Body}";

        var responseString = $"{statusLine}{headersBuilder}{body}";

        return Encoding.UTF8.GetBytes(responseString);
    }
}