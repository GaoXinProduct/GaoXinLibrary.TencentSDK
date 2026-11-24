namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>删除设备的请求。</summary>
public sealed class DeleteTrustedDevicesRequest
{
    /// <summary>要删除的设备类型。</summary>
    [JsonPropertyName("type")] public required int Type { get; init; }

    /// <summary>待删除的设备标识列表。</summary>
    [JsonPropertyName("device_code_list")] public required string[] DeviceCodeList { get; init; }
}
