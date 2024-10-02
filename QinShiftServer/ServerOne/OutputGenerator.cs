
using System.Text;

internal static class OutputGenerator
{
    private const string HttpVersion = "HTTP/1.1";
    internal static ReadOnlySpan<byte> MakeResponse()
    {
        return Encoding.UTF8.GetBytes("Hello from server");
    }
}