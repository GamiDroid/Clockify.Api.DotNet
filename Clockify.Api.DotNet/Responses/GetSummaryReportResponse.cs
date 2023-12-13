using Clockify.Api.DotNet.Models;

namespace Clockify.Api.DotNet.Responses;

public class GetSummaryReportResponse : Response
{
    public SummaryReportDto SummaryReport => Data as SummaryReportDto ?? new();
}