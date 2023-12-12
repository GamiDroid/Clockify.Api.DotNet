using System.Net;
using System.Net.Http.Json;

namespace Clockify.Api.DotNet;
public class Response<T> 
    where T : new()
{
    public required HttpStatusCode StatusCode { get; init; }
    public required T Data { get; init; }

    public bool IsSuccessStatusCode => ((int) StatusCode >= 200) && ((int) StatusCode <= 299);
}
