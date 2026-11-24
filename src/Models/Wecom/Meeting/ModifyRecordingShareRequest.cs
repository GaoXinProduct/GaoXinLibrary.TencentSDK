using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

public sealed class ModifyRecordingShareRequest
{
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    [JsonPropertyName("meeting_record_id")]
    public string MeetingRecordId { get; set; } = string.Empty;

    [JsonPropertyName("sharing_config")]
    public RecordingSharingConfig? SharingConfig { get; set; }

    [Obsolete("请使用会议录制 ID，而不是录制文件 ID。")]
    [JsonIgnore]
    public string RecordFileId { get; set; } = string.Empty;

    [Obsolete("请通过 SharingConfig.AllowDownload 设置下载权限。")]
    [JsonIgnore]
    public int AllowDownload { get; set; }

    [Obsolete("请通过 SharingConfig.SharingAuthType 设置共享权限。")]
    [JsonIgnore]
    public List<string>? AllowedUsers { get; set; }

    [Obsolete("录制共享接口不支持域名列表。")]
    [JsonIgnore]
    public List<string>? AllowedDomains { get; set; }
}

/// <summary>会议录制共享设置。</summary>
public sealed class RecordingSharingConfig
{
    [JsonPropertyName("enable_sharing")] public bool? EnableSharing { get; set; }
    [JsonPropertyName("sharing_auth_type")] public int? SharingAuthType { get; set; }
    [JsonPropertyName("enable_password")] public bool? EnablePassword { get; set; }
    [JsonPropertyName("password")] public string? Password { get; set; }
    [JsonPropertyName("enable_sharing_expire")] public bool? EnableSharingExpiration { get; set; }
    [JsonPropertyName("sharing_expire")] public long? SharingExpiresAt { get; set; }
    [JsonPropertyName("allow_download")] public bool? AllowDownload { get; set; }
}

public sealed class ModifyRecordingShareResponse : WecomBaseResponse
{
}
