using System.Runtime.Serialization;

namespace Clockify.Api.DotNet.Models;

public enum UserStatus
{
    Active,
    PendingEmailVerification,
    Deleted,
    Declined,
    Inactive,
    NotRegistered
}