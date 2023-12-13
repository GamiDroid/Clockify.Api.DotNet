namespace Clockify.Api.DotNet.Models;
public sealed class CurrentUserInfo
{
    public string? ActiveWorkspace { get; set; }
    public string? DefaultWorkspace { get; set; }
    public string? Email { get; set; }
    public string? Id { get; set; }
    public ICollection<MembershipDto> Memberships { get; set; } = Array.Empty<MembershipDto>();
    public string? Name { get; set; }
    public string? ProfilePicture { get; set; }
    public UserSettingsDto? Settings { get; set; }
    public UserStatus? Status { get; set; }
}

public sealed class UserSettingsDto
{
    public bool? CollapseAllProjectLists { get; set; }
    public bool? DashboardPinToTop { get; set; }
    public DashboardSelection? DashboardSelection { get; set; }
    public DashboardViewType? DashboardViewType { get; set; }
    public string? DateFormat { get; set; }
    public bool? IsCompactViewOn { get; set; }
    public bool? LongRunning { get; set; }
    public int? ProjectListCollapse { get; set; }
    public bool? SendNewsletter { get; set; }
    public SummaryReportSettingsDto? SummaryReportSettingsDto { get; set; }
    public string? TimeFormat { get; set; }
    public bool? TimeTrackingManual { get; set; }
    public string? TimeZone { get; set; }
    public WeekDay? WeekStart { get; set; }
    public bool? WeeklyUpdates { get; set; }
}

public enum DashboardViewType
{
    Project,
    Billability
}

public enum DashboardSelection
{
    Me,
    Team
}