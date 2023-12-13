
using Clockify.Api.DotNet;

using var clockify = new ClockifyApiClient("ZjJiMTM1ZGQtMWE0Ni00NTk0LWI1MDYtNWEyMDM3ZDE5ZDlm");

var response = await clockify.GetCurrentUserInfoAsync();

if (!response.IsSuccessStatusCode)
    return;

var currentUserInfo = response.CurrentUserInfo;

try
{
    var response2 = await clockify.GetSummaryReportAsync(
        currentUserInfo.DefaultWorkspace,
        dateRangeStart: new DateTime(2023, 11, 27),
        dateRangeEnd: new DateTime(2023, 12, 03, 23, 59, 59));

    if (!response2.IsSuccessStatusCode) return;

    Console.WriteLine($"projects {response2.SummaryReport}");
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

Console.ReadLine();