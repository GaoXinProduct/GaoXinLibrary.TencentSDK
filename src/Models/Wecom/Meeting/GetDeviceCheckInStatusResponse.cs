using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取成员设备是否入会响应</summary>
/// <remarks>doc path: /98165</remarks>
public class GetDeviceCheckInStatusResponse : WecomBaseResponse
{
    /// <summary>设备入会状态列表</summary>
    [JsonPropertyName("device_checkin_list")]
    public List<DeviceCheckInInfo>? DeviceCheckInList { get; set; }
}

/// <summary>设备入会状态信息</summary>
public class DeviceCheckInInfo
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    /// <summary>是否入会：true-已入会，false-未入会</summary>
    [JsonPropertyName("is_checkin")]
    public bool IsCheckIn { get; set; }
}