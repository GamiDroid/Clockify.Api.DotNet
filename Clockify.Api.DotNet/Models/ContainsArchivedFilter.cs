
namespace Clockify.Api.DotNet.Models;

public sealed class ContainsArchivedFilter : ContainsIdsFilter
{
    public StatusType Status { get; set; }
}

public enum StatusType
{
    All,
    Active,
    Archived
}