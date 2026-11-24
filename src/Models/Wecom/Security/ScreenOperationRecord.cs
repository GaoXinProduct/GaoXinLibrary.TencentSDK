namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>一条截屏或录屏操作记录。</summary>
public sealed class ScreenOperationRecord
{
    /// <summary>操作时间，Unix 时间戳，单位为秒。</summary>
    [JsonPropertyName("time")] public long Time { get; set; }

    /// <summary>操作成员账号。</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>操作成员所属部门 ID。</summary>
    [JsonPropertyName("department_id")] public long DepartmentId { get; set; }

    /// <summary>截屏和录屏内容类型。</summary>
    [JsonPropertyName("screen_shot_type")] public int ScreenshotType { get; set; }

    /// <summary>截屏或录屏的内容描述。</summary>
    [JsonPropertyName("screen_shot_content")] public string? ScreenshotContent { get; set; }

    /// <summary>系统类型。</summary>
    [JsonPropertyName("system")] public string? System { get; set; }

    /// <summary>截屏或录屏操作类型。</summary>
    [JsonPropertyName("operation_type")] public int? OperationType { get; set; }

    /// <summary>操作时的 IP 信息。</summary>
    [JsonPropertyName("ip")] public string? Ip { get; set; }

    /// <summary>执行操作的设备信息。</summary>
    [JsonPropertyName("device_info")] public ScreenOperationDeviceInfo? DeviceInfo { get; set; }
}
