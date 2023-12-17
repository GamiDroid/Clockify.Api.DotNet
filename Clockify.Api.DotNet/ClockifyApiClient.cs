﻿
using Clockify.Api.DotNet.Converters;
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
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
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

    public async Task<GetSummaryReportResponse> GetSummaryReportAsync(string? workspaceId, GetSummaryReportRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(
            GetReportApiRequestUri($"workspaces/{workspaceId}/reports/summary"), request, options: _serializerOptions);

        if (!response.IsSuccessStatusCode)
        {
#if DEBUG
            if (response.RequestMessage is not null && response.RequestMessage.Content is not null)
            {
                var requestBody = await response.RequestMessage.Content.ReadAsStringAsync();
                await Console.Out.WriteLineAsync(requestBody);
            }
#endif

            var message = await response.Content.ReadAsStringAsync();
            return new GetSummaryReportResponse { StatusCode = response.StatusCode, Message = message };
        }
        var summaryReport = await response.Content.ReadFromJsonAsync<SummaryReportDto>(options: _serializerOptions);
        return new GetSummaryReportResponse { StatusCode = response.StatusCode, Data = summaryReport };
    }

    public Task<GetSummaryReportResponse> GetSummaryReportAsync(string? workspaceId, DateTimeOffset dateRangeStart, DateTimeOffset dateRangeEnd)
    {
        return GetSummaryReportAsync(workspaceId, new GetSummaryReportRequest(dateRangeStart, dateRangeEnd, new SummaryFilter
        {
            SummaryChartType = "PROJECT",
            SortColumn = SortColumnType.GROUP,
            Groups = [GroupType.PROJECT, GroupType.TASK, GroupType.TIMEENTRY]
        }));
    }

    private static Uri GetApiRequestUri(string requestUri) => new(new Uri(c_apiBaseUri), requestUri);
    private static Uri GetReportApiRequestUri(string requestUri) => new(new Uri(c_reportsApiBaseUri), requestUri);

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}