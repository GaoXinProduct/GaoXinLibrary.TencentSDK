using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>获取设备打卡数据响应</summary>
public class GetCheckinDeviceDataResponse : WecomBaseResponse
{
    /// <summary>设备打卡记录列表</summary>
    [JsonPropertyName("checkindata")] public DeviceCheckinDataItem[]? CheckinData { get; set; }
}

