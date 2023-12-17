using System.Text.Json.Serialization;

namespace Clockify.Api.DotNet.Models;

public sealed class SummaryFilter
{
    public ICollection<GroupType>? Groups { get; set; }

    // SETTINGS (OPTIONAL)
    public SortColumnType SortColumn { get; set; }
    public string? SummaryChartType { get; set; }
}


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortColumnType
{
    GROUP,
    DURATION,
    AMOUNT,
    DATE
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GroupType
{
    PROJECT,
    CLIENT,
    TASK,
    TAG,
    DATE,
    USER,
    USERGROUP,
    TIMEENTRY
}