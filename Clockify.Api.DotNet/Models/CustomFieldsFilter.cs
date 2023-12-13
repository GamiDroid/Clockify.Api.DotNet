
namespace Clockify.Api.DotNet.Models;

public sealed class CustomFieldsFilter
{
    public string? Id { get; set; }
    public string? Value { get; set; }
    public CustomFieldType Type { get; set; }
    public NumberConditionType NumberCondition { get; set; }
    public bool? Empty { get; set; }
    public bool? IsEmpty { get; set; }
}

public enum CustomFieldType
{
    Txt,
    Number,
    DropdownSingle,
    DropdownMultiple,
    Checkbox,
    Link
}

public enum NumberConditionType
{
    Equal,
    GreaterThan,
    LessThan
}
