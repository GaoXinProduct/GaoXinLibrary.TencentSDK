using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>位置消息内容</summary>
public class KfMsgLocation
{
    /// <summary>纬度</summary>
    [JsonPropertyName("latitude")] public double Latitude { get; set; }

    /// <summary>经度</summary>
    [JsonPropertyName("longitude")] public double Longitude { get; set; }

    /// <summary>位置名</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>地址详情</summary>
    [JsonPropertyName("address")] public string? Address { get; set; }
}

