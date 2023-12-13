namespace Clockify.Api.DotNet.Models;

public sealed class ContainsUsersFilter : ContainsIdsFilter
{
    public UsersStatusType Status { get; set; }
}



public enum UsersStatusType
{
    All,
    Active,
    Inactive
}