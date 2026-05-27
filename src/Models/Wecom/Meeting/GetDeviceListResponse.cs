using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取设备列表响应</summary>
/// <remarks>doc path: /98798</remarks>
public class GetDeviceListResponse : WecomBaseResponse
{
    /// <summary>设备列表</summary>
    [JsonPropertyName("devices")]
    public List<RoomDeviceInfo>? Devices { get; set; }
}