using Clockify.Api.DotNet.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Clockify.Api.DotNet.Tests;

public class CurrentUserInfoTests
{
    [Fact]
    public void JsonText_ShouldBeMapped()
    {
        // arrange 
        var json = @"{""id"":""12345667890qwerty"",""email"":""example@example.com"",""name"":""Example Name"",""memberships"":[],""profilePicture"":""https://img.clockify.me/no-user-image.png"",""activeWorkspace"":""0987654321poiuytrewq"",""defaultWorkspace"":""0987654321poiuytrewq"",""settings"":{""weekStart"":""MONDAY"",""timeZone"":""Europe/Amsterdam"",""timeFormat"":""HOUR24"",""dateFormat"":""MM/DD/YYYY"",""sendNewsletter"":false,""weeklyUpdates"":false,""longRunning"":false,""scheduledReports"":true,""approval"":true,""pto"":true,""alerts"":true,""reminders"":true,""timeTrackingManual"":false,""summaryReportSettings"":{""group"":""PROJECT"",""subgroup"":""CLIENT""},""isCompactViewOn"":true,""dashboardSelection"":""ME"",""dashboardViewType"":""PROJECT"",""dashboardPinToTop"":false,""projectListCollapse"":50,""collapseAllProjectLists"":false,""groupSimilarEntriesDisabled"":false,""myStartOfDay"":""08:00"",""projectPickerTaskFilter"":false,""lang"":null,""multiFactorEnabled"":false,""theme"":""DARK"",""scheduling"":true,""onboarding"":true,""showOnlyWorkingDays"":true},""status"":""ACTIVE"",""customFields"":[]}";

        // act
        var actual = JsonSerializer.Deserialize<CurrentUserInfo>(json, new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            Converters = {
                new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseUpper)
            },
        });

        // assert
        Assert.NotNull(actual);
        Assert.Equal("12345667890qwerty", actual.Id);
        Assert.Equal("example@example.com", actual.Email);
        Assert.Equal("Example Name", actual.Name);
    }
}