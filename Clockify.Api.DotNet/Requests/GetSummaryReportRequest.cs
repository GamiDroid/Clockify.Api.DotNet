using Clockify.Api.DotNet.Models;
using System.Runtime.Serialization;

namespace Clockify.Api.DotNet.Requests;
public sealed class GetSummaryReportRequest
{
    public GetSummaryReportRequest(DateTimeOffset dateRangeStart, DateTimeOffset dateRangeEnd)
    {
        DateRangeStart = dateRangeStart;
        DateRangeEnd = dateRangeEnd;
    }

    // REQUIRED
    public DateTimeOffset DateRangeStart { get; set; }
    public DateTimeOffset DateRangeEnd { get; set; }
    public SummaryFilter? SummaryFilter { get; set; }

    // SETTINGS (OPTIONAL)
    public SortOrderType SortOrder { get; set; }
    public ExportType ExportType { get; set; }
    public bool? Rounding { get; set; }
    public AmountShownType AmountShown { get; set; }
    public string? TimeZone { get; set; }

    // FILTERS (OPTIONAL)
    public ContainsUsersFilter? Users { get; set; }
    public InvoicingStateType InvoicingState { get; set; }
    public ApprovalStateType ApprovalState { get; set; }
    public string? UserGroups { get; set; }
    public ContainsArchivedFilter? Clients { get; set; }
    public string? Projects { get; set; }
    public string? Tasks { get; set; }
    public ContainsTagsFilter? Tags { get; set; }
    public bool? Billable { get; set; }
    public string? Description { get; set; }
    public bool? WithoutDescription { get; set; }
    public ICollection<CustomFieldsFilter>? CustomFields { get; set; }
}

public enum SortOrderType
{
    [EnumMember(Value = "ASCENDING")] 
    ASCENDING,
    [EnumMember(Value = "DESCENDING")]
    DESCENDING
}

public enum ExportType
{
    JSON,
    CSV,
    XLSX,
    PDF
}

public enum AmountShownType
{
    HideAmount,
    Eared,
    Cost,
    Profit
}

public enum InvoicingStateType
{
    All,
    Invoiced,
    Uninvoiced
}

public enum ApprovalStateType
{
    Approved,
    Unapproved,
    All
}