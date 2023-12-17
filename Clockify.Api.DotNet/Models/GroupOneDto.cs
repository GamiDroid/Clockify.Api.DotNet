using System.Text.Json.Serialization;

namespace Clockify.Api.DotNet.Models;

public sealed class GroupOneDto
{
    public ICollection<AmountDto> Amounts { get; set; } = [];
    public long Duration { get; set; }

    [JsonPropertyName("_id")]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? NameLowerCase { get; set; }
    public string? Color { get; set; }
    public string? ClientName { get; set; }
}
