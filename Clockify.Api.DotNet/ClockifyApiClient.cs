
namespace Clockify.Api.DotNet;

public class ClockifyApiClient : IDisposable
{
    private readonly HttpClient _httpClient;

    public ClockifyApiClient(string apiKey)
    {
        _httpClient = new HttpClient();
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
