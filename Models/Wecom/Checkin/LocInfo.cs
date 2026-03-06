using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>位置打卡信息</summary>
public class LocInfo
{
    /// <summary>纬度（实际纬度 × 1000000）</summary>
    [JsonPropertyName("lat")] public long Lat { get; set; }

    /// <summary>经度（实际经度 × 1000000）</summary>
    [JsonPropertyName("lng")] public long Lng { get; set; }

    /// <summary>位置名称</summary>
    [JsonPropertyName("loc_title")] public string? LocTitle { get; set; }

    /// <summary>位置详情</summary>
    [JsonPropertyName("loc_detail")] public string? LocDetail { get; set; }

    /// <summary>允许打卡范围（米）</summary>
    [JsonPropertyName("distance")] public int? Distance { get; set; }
}

