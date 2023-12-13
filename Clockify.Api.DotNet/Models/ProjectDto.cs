namespace Clockify.Api.DotNet.Models;
public sealed class ProjectDto
{
    public string? Color { get; set; }
    public string? Duration { get; set; }
    public string? Id { get; set; }
    public ICollection<MembershipDto> Memberships { get; set; } = Array.Empty<MembershipDto>();
    public string? Name { get; set; }
    public string? Note { get; set; }
    public bool? Public { get; set; }
    public string? WorkspaceId { get; set; }
}
