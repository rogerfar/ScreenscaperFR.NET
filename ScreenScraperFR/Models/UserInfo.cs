using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class UserInfoResponse
{
    [JsonPropertyName("ssuser")]
    public UserInfo? UserInfo { get; set; }
}

public class UserInfo
{
    /// <summary>
    /// Username of the user on ScreenScraper.
    /// </summary>
    [JsonPropertyName("id")]
    public required String Username { get; set; }

    /// <summary>
    /// Numeric ID of the user on ScreenScraper.
    /// </summary>
    [JsonPropertyName("numid")]
    public Int32 UserId { get; set; }

    /// <summary>
    /// User level on ScreenScraper.
    /// </summary>
    [JsonPropertyName("niveau")]
    public Int32 UserLevel { get; set; }

    /// <summary>
    /// Financial contribution level on ScreenScraper.
    /// (2 = 1 extra thread, 3+ = 5 extra threads)
    /// </summary>
    [JsonPropertyName("contribution")]
    public Int32 ContributionLevel { get; set; }

    /// <summary>
    /// Number of valid system media contributions.
    /// </summary>
    [JsonPropertyName("uploadsysteme")]
    public Int32 SystemMediaUploads { get; set; }

    /// <summary>
    /// Number of valid text info contributions.
    /// </summary>
    [JsonPropertyName("uploadinfos")]
    public Int32 InfoTextUploads { get; set; }

    /// <summary>
    /// Number of valid ROM associations contributed.
    /// </summary>
    [JsonPropertyName("romasso")]
    public Int32 RomAssociations { get; set; }

    /// <summary>
    /// Number of valid game media contributions.
    /// </summary>
    [JsonPropertyName("uploadmedia")]
    public Int32 GameMediaUploads { get; set; }

    /// <summary>
    /// Number of user proposals approved by moderators.
    /// </summary>
    [JsonPropertyName("propositionok")]
    public Int32 ApprovedProposals { get; set; }

    /// <summary>
    /// Number of user proposals rejected by moderators.
    /// </summary>
    [JsonPropertyName("propositionko")]
    public Int32 RejectedProposals { get; set; }

    /// <summary>
    /// Percentage of user proposals that were rejected.
    /// </summary>
    [JsonPropertyName("quotarefu")]
    public Int32 RejectionRate { get; set; }

    /// <summary>
    /// Number of threads allowed for the user (also applies to non-registered users).
    /// </summary>
    [JsonPropertyName("maxthreads")]
    public Int32 MaxThreads { get; set; }

    /// <summary>
    /// Maximum download speed in KB/s allowed for the user.
    /// </summary>
    [JsonPropertyName("maxdownloadspeed")]
    public Int32 MaxDownloadSpeed { get; set; }

    // API Quotas
    /// <summary>
    /// Total number of API calls made today.
    /// </summary>
    [JsonPropertyName("requeststoday")]
    public Int32 RequestsToday { get; set; }

    /// <summary>
    /// Number of unsuccessful API calls today (e.g., ROM/game not found).
    /// </summary>
    [JsonPropertyName("requestskotoday")]
    public Int32 FailedRequestsToday { get; set; }

    /// <summary>
    /// Maximum number of API calls allowed per minute.
    /// </summary>
    [JsonPropertyName("maxrequestspermin")]
    public Int32 MaxRequestsPerMinute { get; set; }

    /// <summary>
    /// Maximum number of API calls allowed per day.
    /// </summary>
    [JsonPropertyName("maxrequestsperday")]
    public Int32 MaxRequestsPerDay { get; set; }

    /// <summary>
    /// Maximum number of failed API calls allowed per day.
    /// </summary>
    [JsonPropertyName("maxrequestskoperday")]
    public Int32 MaxFailedRequestsPerDay { get; set; }

    /// <summary>
    /// Total number of visits to ScreenScraper.
    /// </summary>
    [JsonPropertyName("visites")]
    public Int32 VisitCount { get; set; }

    /// <summary>
    /// Date and time of the user's last visit.
    /// </summary>
    [JsonPropertyName("datedernierevisite")]
    [JsonConverter(typeof(JsonDateTimeOffsetConverter))]
    public DateTimeOffset LastVisitDate { get; set; }

    /// <summary>
    /// User's favorite region.
    /// </summary>
    [JsonPropertyName("favregion")]
    public String? FavoriteRegion { get; set; }
}
