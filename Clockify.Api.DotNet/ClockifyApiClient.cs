
using Clockify.Api.DotNet.Models;
using Clockify.Api.DotNet.Responses;
using System.Net.Http.Json;

namespace Clockify.Api.DotNet;

public class ClockifyApiClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private const string c_baseUri = "https://api.clockify.me/api/v1/";

    public ClockifyApiClient(string apiKey)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(c_baseUri),
        };
        _httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
    }

    public async Task<GetCurrentUserInfoResponse> GetCurrentUserInfoAsync()
    {
        var response = await _httpClient.GetAsync("user");

        if (!response.IsSuccessStatusCode)
            return new GetCurrentUserInfoResponse { StatusCode = response.StatusCode, Data = new() };
        var currentUserInfo = await response.Content.ReadFromJsonAsync<CurrentUserInfo>();
        return new GetCurrentUserInfoResponse { StatusCode = response.StatusCode, Data = currentUserInfo ?? new() };
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
