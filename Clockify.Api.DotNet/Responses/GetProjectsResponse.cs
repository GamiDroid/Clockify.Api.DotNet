using Clockify.Api.DotNet.Models;

namespace Clockify.Api.DotNet.Responses;
public class GetProjectsResponse : Response
{
    public ICollection<ProjectDto> Projects => Data as ICollection<ProjectDto> ?? Array.Empty<ProjectDto>();
}
