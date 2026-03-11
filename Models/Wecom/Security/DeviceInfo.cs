using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>设备信息</summary>
public class DeviceInfo
{
    /// <summary>设备系统 android/ios/windows/mac</summary>
    [JsonPropertyName("os")] public string? Os { get; set; }

    /// <summary>设备名称</summary>
    [JsonPropertyName("device_name")] public string? DeviceName { get; set; }

    /// <summary>设备唯一标识</summary>
    [JsonPropertyName("device_code")] public string? DeviceCode { get; set; }

    /// <summary>最近登录时间</summary>
    [JsonPropertyName("last_login_time")] public long LastLoginTime { get; set; }
}
