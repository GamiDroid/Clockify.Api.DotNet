
using Clockify.Api.DotNet;

using var clockify = new ClockifyApiClient("ZjJiMTM1ZGQtMWE0Ni00NTk0LWI1MDYtNWEyMDM3ZDE5ZDlm");

var response = await clockify.GetCurrentUserInfoAsync();

if (!response.IsSuccessStatusCode)
    return;

var currentUserInfo = response.CurrentUserInfo;
var response2 = await clockify.GetProjectsAsync(currentUserInfo.DefaultWorkspace);

if (!response2.IsSuccessStatusCode) return;

Console.WriteLine($"projects {response2.Projects.Count}");