using System.Net;

namespace Clockify.Api.DotNet;
public class Response
{
    public HttpStatusCode StatusCode { get; init; }
    public object? Data { get; init; }

    public bool IsSuccessStatusCode => ((int) StatusCode >= 200) && ((int) StatusCode <= 299);
}
