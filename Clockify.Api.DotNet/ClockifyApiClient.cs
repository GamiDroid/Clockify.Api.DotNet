
using Clockify.Api.DotNet.Models;
using Clockify.Api.DotNet.Requests;
using Clockify.Api.DotNet.Responses;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Clockify.Api.DotNet;

public class ClockifyApiClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _serializerOptions;

    private const string c_apiBaseUri = "https://api.clockify.me/api/v1/";
    private const string c_reportsApiBaseUri = "https://reports.api.clockify.me/v1/";

    public ClockifyApiClient(string apiKey)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
        _serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            Converters = {
                new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseUpper),
                new DateTimeOffsetConverter(),
            },
        };
    }

    public async Task<GetCurrentUserInfoResponse> GetCurrentUserInfoAsync()
    {
        var response = await _httpClient.GetAsync(GetApiRequestUri("user"));
        if (!response.IsSuccessStatusCode)
            return new GetCurrentUserInfoResponse { StatusCode = response.StatusCode };
        var currentUserInfo = await response.Content.ReadFromJsonAsync<CurrentUserInfo>(options: _serializerOptions);
        return new GetCurrentUserInfoResponse { StatusCode = response.StatusCode, Data = currentUserInfo };
    }

    public async Task<GetProjectsResponse> GetProjectsAsync(string workspaceId)
    {
        var response = await _httpClient.GetAsync(GetApiRequestUri($"workspaces/{workspaceId}/projects"));
        if (!response.IsSuccessStatusCode)
            return new GetProjectsResponse { StatusCode = response.StatusCode };
        var projects = await response.Content.ReadFromJsonAsync<ICollection<ProjectDto>>(options: _serializerOptions);
        return new GetProjectsResponse { StatusCode = response.StatusCode, Data = projects };
    }

    public async Task<GetSummaryReportResponse> GetSummaryReportAsync(string workspaceId, DateTimeOffset dateRangeStart, DateTimeOffset dateRangeEnd)
    {
        var response = await _httpClient.PostAsJsonAsync(
            GetReportApiRequestUri($"workspaces/{workspaceId}/reports/summary"), 
            new GetSummaryReportRequest(dateRangeStart, dateRangeEnd));

        var requestJson = await response.RequestMessage.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            var message = await response.Content.ReadAsStringAsync();
            return new GetSummaryReportResponse { StatusCode = response.StatusCode, Message = message };
        }
        var summaryReport = await response.Content.ReadFromJsonAsync<ICollection<ProjectDto>>(options: _serializerOptions);
        return new GetSummaryReportResponse { StatusCode = response.StatusCode, Data = summaryReport };
    }

    private static Uri GetApiRequestUri(string requestUri) => new(new Uri(c_apiBaseUri), requestUri);
    private static Uri GetReportApiRequestUri(string requestUri) => new(new Uri(c_reportsApiBaseUri), requestUri);

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
