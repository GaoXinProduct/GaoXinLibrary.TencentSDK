using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class DeleteRecordingRequest
{
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    [JsonPropertyName("record_fileids")]
    public List<string>? RecordFileIds { get; set; }
}

public sealed class DeleteRecordingResponse : WecomBaseResponse
{
}