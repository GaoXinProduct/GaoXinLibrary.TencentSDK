using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>WiFi 打卡信息</summary>
public class WifiMacInfo
{
    /// <summary>WiFi 名称</summary>
    [JsonPropertyName("wifiname")] public string? WifiName { get; set; }

    /// <summary>WiFi MAC 地址</summary>
    [JsonPropertyName("wifimac")] public string? WifiMac { get; set; }
}

