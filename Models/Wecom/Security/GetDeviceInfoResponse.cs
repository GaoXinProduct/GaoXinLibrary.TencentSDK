using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>设备管理-获取成员使用设备响应</summary>
public class GetDeviceInfoResponse : WecomBaseResponse
{
    /// <summary>设备信息列表</summary>
    [JsonPropertyName("device_list")] public DeviceInfo[]? DeviceList { get; set; }
}
