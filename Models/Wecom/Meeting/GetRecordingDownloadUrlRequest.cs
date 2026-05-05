using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class GetRecordingDownloadUrlRequest
{
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    [JsonPropertyName("record_fileid")]
    public string RecordFileId { get; set; } = string.Empty;

    [JsonPropertyName("download_type")]
    public int DownloadType { get; set; }
}

public sealed class GetRecordingDownloadUrlResponse : WecomBaseResponse
{
    [JsonPropertyName("download_url")]
    public string? DownloadUrl { get; set; }

    [JsonPropertyName("expires_time")]
    public long ExpiresTime { get; set; }
}