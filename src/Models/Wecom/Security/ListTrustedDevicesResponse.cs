using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>一页设备信息。</summary>
public sealed class ListTrustedDevicesResponse : WecomBaseResponse
{
    /// <summary>设备信息列表。</summary>
    [JsonPropertyName("device_list")] public DeviceInfo[]? DeviceList { get; set; }

    /// <summary>下一页查询使用的游标。</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}
