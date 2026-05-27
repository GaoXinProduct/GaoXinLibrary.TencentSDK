using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class ModifyRecordingShareRequest
{
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    [JsonPropertyName("record_fileid")]
    public string RecordFileId { get; set; } = string.Empty;

    [JsonPropertyName("allow_download")]
    public int AllowDownload { get; set; }

    [JsonPropertyName("allowed_users")]
    public List<string>? AllowedUsers { get; set; }

    [JsonPropertyName("allowed_domains")]
    public List<string>? AllowedDomains { get; set; }
}

public sealed class ModifyRecordingShareResponse : WecomBaseResponse
{
}