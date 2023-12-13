namespace Clockify.Api.DotNet.Models;

public class SummaryReportDto
{
    public ICollection<TotalsDto> Totals { get; set; } = Array.Empty<TotalsDto>();
    public ICollection<GroupOneDto> GroupOne { get; set; } = Array.Empty<GroupOneDto>();
}
