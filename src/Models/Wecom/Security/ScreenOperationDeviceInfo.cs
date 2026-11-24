namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>截屏或录屏操作的设备信息。</summary>
public sealed class ScreenOperationDeviceInfo
{
    /// <summary>设备平台。</summary>
    [JsonPropertyName("platform")] public string? Platform { get; set; }

    /// <summary>设备标识。</summary>
    [JsonPropertyName("device_code")] public string? DeviceCode { get; set; }

    /// <summary>设备型号。</summary>
    [JsonPropertyName("device_model")] public string? DeviceModel { get; set; }

    /// <summary>Windows 平台的详细信息。</summary>
    [JsonPropertyName("windows")] public WindowsDevice? Windows { get; set; }

    /// <summary>Mac 平台的详细信息。</summary>
    [JsonPropertyName("mac")] public MacDevice? Mac { get; set; }

    /// <summary>移动设备的详细信息。</summary>
    [JsonPropertyName("mobile")] public MobileDevice? Mobile { get; set; }

    /// <summary>Windows 平台的详细信息。</summary>
    public sealed class WindowsDevice
    {
        /// <summary>设备 MAC 地址。</summary>
        [JsonPropertyName("mac_addr")] public string[]? MacAddresses { get; set; }

        /// <summary>主板 UUID。</summary>
        [JsonPropertyName("motherboard_uuid")] public string? MotherboardUuid { get; set; }

        /// <summary>硬盘 UUID。</summary>
        [JsonPropertyName("harddisk_uuid")] public string[]? HardDiskUuids { get; set; }

        /// <summary>Windows 域名。</summary>
        [JsonPropertyName("domain")] public string? Domain { get; set; }

        /// <summary>计算机名。</summary>
        [JsonPropertyName("pc_name")] public string? PcName { get; set; }
    }

    /// <summary>Mac 平台的详细信息。</summary>
    public sealed class MacDevice
    {
        /// <summary>设备 MAC 地址。</summary>
        [JsonPropertyName("mac_addr")] public string[]? MacAddresses { get; set; }

        /// <summary>设备序列号。</summary>
        [JsonPropertyName("seq_no")] public string? SequenceNumber { get; set; }
    }

    /// <summary>移动设备的详细信息。</summary>
    public sealed class MobileDevice
    {
        /// <summary>移动设备类型。</summary>
        [JsonPropertyName("type")] public int Type { get; set; }
    }
}
