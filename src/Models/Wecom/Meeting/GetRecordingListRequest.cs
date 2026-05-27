using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class GetRecordingListRequest
{
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    [JsonPropertyName("record_fileid")]
    public string? RecordFileId { get; set; }

    [JsonPropertyName("page_size")]
    public int PageSize { get; set; } = 100;

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}

public sealed class GetRecordingListResponse : WecomBaseResponse
{
    [JsonPropertyName("recording_list")]
    public List<RecordingInfo>? RecordingList { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}

public sealed class RecordingInfo
{
    [JsonPropertyName("record_fileid")]
    public string RecordFileId { get; set; } = string.Empty;

    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    [JsonPropertyName("subject")]
    public string Subject { get; set; } = string.Empty;

    [JsonPropertyName("record_type")]
    public int RecordType { get; set; }

    [JsonPropertyName("record_url")]
    public string RecordUrl { get; set; } = string.Empty;

    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    [JsonPropertyName("size")]
    public long Size { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }
}