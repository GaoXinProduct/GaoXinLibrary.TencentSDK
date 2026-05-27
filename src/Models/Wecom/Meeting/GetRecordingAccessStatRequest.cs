using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class GetRecordingAccessStatRequest
{
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    [JsonPropertyName("record_fileid")]
    public string? RecordFileId { get; set; }
}

public sealed class GetRecordingAccessStatResponse : WecomBaseResponse
{
    [JsonPropertyName("access_stats")]
    public List<AccessStatItem>? AccessStats { get; set; }
}

public sealed class AccessStatItem
{
    [JsonPropertyName("record_fileid")]
    public string RecordFileId { get; set; } = string.Empty;

    [JsonPropertyName("view_count")]
    public int ViewCount { get; set; }

    [JsonPropertyName("download_count")]
    public int DownloadCount { get; set; }

    [JsonPropertyName("share_count")]
    public int ShareCount { get; set; }
}