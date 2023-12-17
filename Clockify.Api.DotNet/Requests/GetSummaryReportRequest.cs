using Clockify.Api.DotNet.Converters;
using Clockify.Api.DotNet.Models;
using System.Text.Json.Serialization;

namespace Clockify.Api.DotNet.Requests;
public sealed class GetSummaryReportRequest
{
    public GetSummaryReportRequest(DateTimeOffset dateRangeStart, DateTimeOffset dateRangeEnd, SummaryFilter summaryFilter)
    {
        DateRangeStart = dateRangeStart;
        DateRangeEnd = dateRangeEnd;
        SummaryFilter = summaryFilter;
    }

    // REQUIRED
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset DateRangeStart { get; set; }
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset DateRangeEnd { get; set; }
    public SummaryFilter SummaryFilter { get; set; }

    // SETTINGS (OPTIONAL)
    public SortOrderType? SortOrder { get; set; }
    public ExportType? ExportType { get; set; }
    public bool? Rounding { get; set; }
    public AmountShownType? AmountShown { get; set; }
    public string? TimeZone { get; set; }

    // FILTERS (OPTIONAL)
    public ContainsUsersFilter? Users { get; set; }
    public InvoicingStateType? InvoicingState { get; set; }
    public ApprovalStateType? ApprovalState { get; set; }
    public string? UserGroups { get; set; }
    public ContainsArchivedFilter? Clients { get; set; }
    public string? Projects { get; set; }
    public string? Tasks { get; set; }
    public ContainsTagsFilter? Tags { get; set; }
    public bool? Billable { get; set; }
    public string? Description { get; set; }
    public bool? WithoutDescription { get; set; }
    public ICollection<CustomFieldsFilter>? CustomFields { get; set; }
    public ICollection<CustomFieldsFilter>? UserCustomFields { get; set; }
    public string? ZoomLevel { get; set; }
    public string? UserLocale { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortOrderType
{
    ASCENDING,
    DESCENDING
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ExportType
{
    JSON,
    CSV,
    XLSX,
    PDF
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AmountShownType
{
    HIDE_AMOUNT,
    EARED,
    COST,
    PROFIT
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum InvoicingStateType
{
    ALL,
    INVOICED,
    UNINVOICED
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApprovalStateType
{
    APPROVED,
    UNAPPROVED,
    ALL
}