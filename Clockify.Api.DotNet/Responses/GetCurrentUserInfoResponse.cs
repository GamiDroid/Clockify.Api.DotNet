using Clockify.Api.DotNet.Models;

namespace Clockify.Api.DotNet.Responses;
public class GetCurrentUserInfoResponse : Response<CurrentUserInfo>
{
    public CurrentUserInfo CurrentUserInfo => Data;
}
