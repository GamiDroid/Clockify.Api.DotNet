
using Clockify.Api.DotNet;

using var clockify = new ClockifyApiClient("ZjJiMTM1ZGQtMWE0Ni00NTk0LWI1MDYtNWEyMDM3ZDE5ZDlm");

var response = await clockify.GetCurrentUserInfoAsync();

if (response.IsSuccessStatusCode)
{
    var currentUserInfo = response.CurrentUserInfo;
}