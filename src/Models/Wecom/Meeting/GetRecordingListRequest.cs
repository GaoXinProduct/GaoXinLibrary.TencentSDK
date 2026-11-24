using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class GetRecordingListRequest
{
    /// <summary>优先按会议 ID 查询。</summary>
    [JsonPropertyName("meetingid")]
    public string? MeetingId { get; set; }

    /// <summary>无会议 ID 时可按会议号查询。</summary>
    [JsonPropertyName("meeting_code")]
    public string? MeetingCode { get; set; }

    /// <summary>也可查询指定成员的会议录制。</summary>
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    /// <summary>查询起始时间（Unix 秒）。查询跨度最多 31 天。</summary>
    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    [Obsolete("录制列表接口不支持按录制文件 ID 查询。")]
    [JsonIgnore]
    public string? RecordFileId { get; set; }

    /// <summary>分页大小，默认 10，最大 20。</summary>
    [JsonPropertyName("limit")]
    public int PageSize { get; set; } = 10;

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}

public sealed class GetRecordingListResponse : WecomBaseResponse
{
    [JsonPropertyName("record_meetings")]
    public List<RecordingInfo>? RecordingList { get; set; }

    [JsonInclude]
    [JsonPropertyName("record_list")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    internal List<RecordingInfo>? RecordListAlias
    {
        get => null;
        set => RecordingList ??= value;
    }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}

public sealed class RecordingInfo
{
    /// <summary>会议录制 ID。具体录制文件 ID 位于 <see cref="RecordFiles"/>。</summary>
    [JsonPropertyName("meeting_record_id")]
    public string? MeetingRecordId { get; set; }

    [JsonPropertyName("record_fileid")]
    public string RecordFileId { get; set; } = string.Empty;

    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Subject { get; set; } = string.Empty;

    [JsonPropertyName("meeting_code")]
    public string? MeetingCode { get; set; }

    [JsonPropertyName("host_user_id")]
    public string? HostUserId { get; set; }

    [JsonPropertyName("record_type")]
    public int RecordType { get; set; }

    [JsonPropertyName("record_url")]
    public string RecordUrl { get; set; } = string.Empty;

    /// <summary>会议开始时间（Unix 毫秒）。</summary>
    [JsonPropertyName("meeting_start_time")]
    public long StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>录制状态。1 录制中，3 转码完成。</summary>
    [JsonPropertyName("state")]
    public int Status { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("record_files")]
    public List<RecordingFileInfo>? RecordFiles { get; set; }

    [JsonInclude]
    [JsonPropertyName("record_file_list")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    internal List<RecordingFileInfo>? RecordFileListAlias
    {
        get => null;
        set => RecordFiles ??= value;
    }
}

/// <summary>会议录制文件的元数据与共享配置。</summary>
public sealed class RecordingFileInfo
{
    [JsonPropertyName("record_file_id")] public string? RecordFileId { get; set; }
    [JsonPropertyName("record_start_time")] public long StartTime { get; set; }
    [JsonPropertyName("record_end_time")] public long EndTime { get; set; }
    [JsonPropertyName("record_size")] public long Size { get; set; }
    [JsonPropertyName("sharing_state")] public int SharingState { get; set; }
    [JsonPropertyName("sharing_url")] public string? SharingUrl { get; set; }
    [JsonPropertyName("required_same_corp")] public bool? RequiredSameCorp { get; set; }
    [JsonPropertyName("required_attendee")] public bool? RequiredAttendee { get; set; }
    [JsonPropertyName("password")] public string? Password { get; set; }
    [JsonPropertyName("sharing_expire")] public long? SharingExpiresAt { get; set; }
    [JsonPropertyName("allow_download")] public bool? AllowDownload { get; set; }
}
