namespace Clockify.Api.DotNet.Models;

public sealed class TotalsDto
{
    public ICollection<AmountDto> Amounts { get; set; } = Array.Empty<AmountDto>();
    public int EntriesCount { get; set; }
    public string? Id { get; set; }
    public int TotalBillableTime { get; set; }
    public int TotalTime { get; set; }
}
