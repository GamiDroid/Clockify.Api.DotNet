namespace Clockify.Api.DotNet.Models;

public sealed class AmountDto
{
    public decimal Value { get; set; }
    public AmountType Type { get; set; }
}

public enum AmountType
{
    Earned,
    Cost,
    Profit,
    HideAmount
}