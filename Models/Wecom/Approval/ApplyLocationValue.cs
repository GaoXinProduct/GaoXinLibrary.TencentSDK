using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>位置值</summary>
public class ApplyLocationValue
{
    /// <summary>纬度</summary>
    [JsonPropertyName("latitude")] public string? Latitude { get; set; }

    /// <summary>经度</summary>
    [JsonPropertyName("longitude")] public string? Longitude { get; set; }

    /// <summary>位置名称</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>位置地址</summary>
    [JsonPropertyName("address")] public string? Address { get; set; }

    /// <summary>精确到多少米</summary>
    [JsonPropertyName("time")] public int? Time { get; set; }
}

