namespace Clockify.Api.DotNet.Models;

public class ContainsIdsFilter
{
    public HashSet<string> Ids { get; set; } = [];
    public ContainsType Contains { get; set; }
}

public enum ContainsType
{
    Contains,
    DoesNotContain,
    ContainsOnly
}
