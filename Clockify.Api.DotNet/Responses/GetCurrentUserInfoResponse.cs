using Clockify.Api.DotNet.Models;

namespace Clockify.Api.DotNet.Responses;
public class GetCurrentUserInfoResponse : Response
{
    public CurrentUserInfo CurrentUserInfo => Data as CurrentUserInfo ?? new();
}
