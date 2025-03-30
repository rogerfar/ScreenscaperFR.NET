using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class ServerInfrastructureInfoResponse
{
    [JsonPropertyName("serveurs")]
    public ServerInfrastructureInfo ServerInfrastructureInfo { get; set; } = new();
}

public class ServerInfrastructureInfo
{
    /// <summary>
    /// CPU usage (%) of server 1 (average over the last 5 minutes).
    /// </summary>
    [JsonPropertyName("cpu1")]
    public Int32 CpuUsageServer1 { get; set; }

    /// <summary>
    /// CPU usage (%) of server 2 (average over the last 5 minutes).
    /// </summary>
    [JsonPropertyName("cpu2")]
    public Int32 CpuUsageServer2 { get; set; }

    /// <summary>
    /// CPU usage (%) of server 3 (average over the last 5 minutes).
    /// </summary>
    [JsonPropertyName("cpu3")]
    public Int32 CpuUsageServer3 { get; set; }

    /// <summary>
    /// CPU usage (%) of server 4 (average over the last 5 minutes).
    /// </summary>
    [JsonPropertyName("cpu4")]
    public Int32 CpuUsageServer4 { get; set; }

    /// <summary>
    /// Number of API accesses in the last minute.
    /// </summary>
    [JsonPropertyName("threadsmin")]
    public Int32 ApiAccessesLastMinute { get; set; }

    /// <summary>
    /// Number of scrapers using the API in the last minute.
    /// </summary>
    [JsonPropertyName("nbscrapeurs")]
    public Int32 ActiveScrapersLastMinute { get; set; }

    /// <summary>
    /// Total number of API accesses today (GMT+1).
    /// </summary>
    [JsonPropertyName("apiacces")]
    [JsonConverter(typeof(JsonInt32Converter))]
    public Int32? ApiAccessesToday { get; set; }

    /// <summary>
    /// Indicates whether the API is closed to anonymous users (true = closed).
    /// </summary>
    [JsonPropertyName("closefornomember")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsClosedForNonMembers { get; set; }

    /// <summary>
    /// Indicates whether the API is closed to non-contributing members (true = closed).
    /// </summary>
    [JsonPropertyName("closeforleecher")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsClosedForLeechers { get; set; }

    /// <summary>
    /// Maximum number of concurrent threads allowed for anonymous users.
    /// </summary>
    [JsonPropertyName("maxthreadfornonmember")]
    public Int32 MaxThreadsForNonMembers { get; set; }

    /// <summary>
    /// Current number of threads opened by anonymous users.
    /// </summary>
    [JsonPropertyName("threadfornonmember")]
    public Int32 CurrentThreadsForNonMembers { get; set; }

    /// <summary>
    /// Maximum number of concurrent threads allowed for registered members.
    /// </summary>
    [JsonPropertyName("maxthreadformember")]
    public Int32 MaxThreadsForMembers { get; set; }

    /// <summary>
    /// Current number of threads opened by registered members.
    /// </summary>
    [JsonPropertyName("threadformember")]
    public Int32 CurrentThreadsForMembers { get; set; }
}
