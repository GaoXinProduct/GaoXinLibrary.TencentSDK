using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class GetRecordingDownloadUrlRequest
{
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    [JsonPropertyName("meeting_record_id")]
    public string MeetingRecordId { get; set; } = string.Empty;

    [Obsolete("请使用会议录制 ID，而不是录制文件 ID。")]
    [JsonIgnore]
    public string RecordFileId { get; set; } = string.Empty;

    [Obsolete("接口同时返回播放、视频和音频下载地址。")]
    [JsonIgnore]
    public int DownloadType { get; set; }
}

public sealed class GetRecordingDownloadUrlResponse : WecomBaseResponse
{
    [JsonPropertyName("meeting_record_id")] public string? MeetingRecordId { get; set; }
    [JsonPropertyName("meetingid")] public string? MeetingId { get; set; }
    [JsonPropertyName("meeting_code")] public string? MeetingCode { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("record_files")] public List<RecordingFileAddress>? RecordFiles { get; set; }

    [JsonPropertyName("download_url")]
    public string? DownloadUrl { get; set; }

    [JsonPropertyName("expires_time")]
    public long ExpiresTime { get; set; }
}

/// <summary>一个会议录制文件的播放和下载地址。</summary>
public sealed class RecordingFileAddress
{
    [JsonPropertyName("record_file_id")] public string? RecordFileId { get; set; }
    [JsonPropertyName("view_address")] public string? ViewUrl { get; set; }
    [JsonPropertyName("download_address")] public string? DownloadUrl { get; set; }
    [JsonPropertyName("download_address_file_type")] public string? DownloadFileType { get; set; }
    [JsonPropertyName("audio_address")] public string? AudioUrl { get; set; }
    [JsonPropertyName("audio_address_file_type")] public string? AudioFileType { get; set; }
    [JsonPropertyName("meeting_summary")] public List<RecordingSummaryFile>? MeetingSummaries { get; set; }
}

/// <summary>会议纪要文件的下载地址。</summary>
public sealed class RecordingSummaryFile
{
    [JsonPropertyName("download_address")] public string? DownloadUrl { get; set; }
    [JsonPropertyName("file_type")] public string? FileType { get; set; }
}
