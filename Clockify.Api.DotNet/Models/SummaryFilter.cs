using System.Runtime.Serialization;

namespace Clockify.Api.DotNet.Models;

public sealed class SummaryFilter
{
    public ICollection<GroupType> Groups { get; set; } = Array.Empty<GroupType>();

    // SETTINGS (OPTIONAL)
    public SortColumnType SortColumn { get; set; }
    public string? SummaryChartType { get; set; }
}

public enum SortColumnType
{
    Group,
    Duration,
    Amount,
    Date
}

public enum GroupType
{
    Project,
    Client,
    Task,
    Tag,
    Date,
    User,
    UserGroup,
    [EnumMember(Value = "TIMEENTRY")]
    TimeEntry
}