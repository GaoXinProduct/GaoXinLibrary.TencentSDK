
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>设备信息</summary>
public sealed class DeviceInfo
{
    /// <summary>历史字段，设备管理接口返回的系统见 <see cref="System"/>。</summary>
    [JsonPropertyName("os")] public string? Os { get; set; }

    /// <summary>历史设备名称字段，Windows 计算机名见 <see cref="PcName"/>。</summary>
    [JsonPropertyName("device_name")] public string? DeviceName { get; set; }

    /// <summary>设备唯一标识</summary>
    [JsonPropertyName("device_code")] public string? DeviceCode { get; set; }

    /// <summary>最近登录时间</summary>
    [JsonPropertyName("last_login_time")] public long LastLoginTime { get; set; }

    /// <summary>设备系统。</summary>
    [JsonPropertyName("system")] public string? System { get; set; }

    /// <summary>设备 MAC 地址。</summary>
    [JsonPropertyName("mac_addr")] public string[]? MacAddresses { get; set; }

    /// <summary>Windows 设备主板 UUID。</summary>
    [JsonPropertyName("motherboard_uuid")] public string? MotherboardUuid { get; set; }

    /// <summary>Windows 设备硬盘 UUID。</summary>
    [JsonPropertyName("harddisk_uuid")] public string[]? HardDiskUuids { get; set; }

    /// <summary>Windows 域名。</summary>
    [JsonPropertyName("domain")] public string? Domain { get; set; }

    /// <summary>Windows 计算机名。</summary>
    [JsonPropertyName("pc_name")] public string? PcName { get; set; }

    /// <summary>Mac 设备序列号。</summary>
    [JsonPropertyName("seq_no")] public string? SequenceNumber { get; set; }

    /// <summary>最后登录成员账号。</summary>
    [JsonPropertyName("last_login_userid")] public string? LastLoginUserId { get; set; }

    /// <summary>确认时间，Unix 时间戳，单位为秒。</summary>
    [JsonPropertyName("confirm_timestamp")] public long? ConfirmTimestamp { get; set; }

    /// <summary>确认成员账号。</summary>
    [JsonPropertyName("confirm_userid")] public string? ConfirmUserId { get; set; }

    /// <summary>审批成员账号。</summary>
    [JsonPropertyName("approved_userid")] public string? ApprovedUserId { get; set; }

    /// <summary>设备来源。</summary>
    [JsonPropertyName("source")] public int Source { get; set; }

    /// <summary>设备状态。</summary>
    [JsonPropertyName("status")] public int Status { get; set; }
}
