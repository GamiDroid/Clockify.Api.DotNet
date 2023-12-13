namespace Clockify.Api.DotNet.Models;

public sealed class ContainsTagsFilter : ContainsIdsFilter
{
    public ContainsType ContainedInTimeEntry { get; set; }
    public StatusType Status { get; set; }
}
