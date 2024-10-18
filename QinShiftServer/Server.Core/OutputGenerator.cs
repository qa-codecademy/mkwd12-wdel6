using ServerTwo.Interface;

using System.Text;

internal static class OutputGenerator
{
    private const string HttpVersion = "HTTP/1.1";
    internal static ReadOnlySpan<byte> MakeResponse(BaseResponse response)
    {
        var statusLine = $"{HttpVersion} {response.StatusCode}\r\n";
        var headersBuilder = new StringBuilder();
        foreach (var (name, value) in response.Headers)
        {
            headersBuilder.AppendLine($"{name}: {value}");
        }

        var responseString = $"{statusLine}{headersBuilder}\r\n";
        var responseHeaderBytes = Encoding.UTF8.GetBytes(responseString);
        var bodyBytes = response.GetBodyBytes();

        byte[] responseBytes = JoinByteArrays(responseHeaderBytes, bodyBytes);

        return responseBytes;

    }

    private static byte[] JoinByteArrays(byte[] first, byte[] second)
    {
        var result = new byte[first.Length + second.Length];
        ((Span<byte>)first).CopyTo(result);
        second.CopyTo(result.AsSpan(first.Length));
        return result;
    }
}
