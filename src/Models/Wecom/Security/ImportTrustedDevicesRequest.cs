namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>批量导入可信设备的请求。</summary>
public sealed class ImportTrustedDevicesRequest
{
    /// <summary>设备列表。</summary>
    [JsonPropertyName("device_list")] public required TrustedDeviceRegistration[] DeviceList { get; init; }
}

/// <summary>待导入的可信设备。</summary>
public sealed class TrustedDeviceRegistration
{
    /// <summary>设备系统，取值为 Windows 或 Mac。</summary>
    [JsonPropertyName("system")] public required string System { get; init; }

    /// <summary>设备 MAC 地址，Windows 设备必填。</summary>
    [JsonPropertyName("mac_addr")] public string[]? MacAddresses { get; init; }

    /// <summary>Windows 设备主板 UUID。</summary>
    [JsonPropertyName("motherboard_uuid")] public string? MotherboardUuid { get; init; }

    /// <summary>Windows 设备硬盘 UUID。</summary>
    [JsonPropertyName("harddisk_uuid")] public string[]? HardDiskUuids { get; init; }

    /// <summary>Windows 域名。</summary>
    [JsonPropertyName("domain")] public string? Domain { get; init; }

    /// <summary>Windows 计算机名。</summary>
    [JsonPropertyName("pc_name")] public string? PcName { get; init; }

    /// <summary>Mac 设备序列号。</summary>
    [JsonPropertyName("seq_no")] public string? SequenceNumber { get; init; }
}
