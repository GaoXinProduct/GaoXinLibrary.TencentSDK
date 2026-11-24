using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class DeleteRecordingRequest
{
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    [JsonPropertyName("meeting_record_id")]
    public string MeetingRecordId { get; set; } = string.Empty;

    [Obsolete("请使用 MeetingService.DeleteRecordingFileAsync 删除单个录制文件。")]
    [JsonIgnore]
    public List<string>? RecordFileIds { get; set; }
}

public sealed class DeleteRecordingResponse : WecomBaseResponse
{
}

/// <summary>删除单个会议录制文件。</summary>
public sealed class DeleteRecordingFileRequest
{
    [JsonPropertyName("meetingid")] public string MeetingId { get; set; } = string.Empty;
    [JsonPropertyName("record_file_id")] public string RecordFileId { get; set; } = string.Empty;
}
