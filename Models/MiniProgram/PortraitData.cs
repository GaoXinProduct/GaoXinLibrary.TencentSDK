using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>画像数据</summary>
public class PortraitData
{
    /// <summary>省份分布</summary>
    [JsonPropertyName("province")] public List<PortraitItem>? Province { get; set; }
    /// <summary>城市分布</summary>
    [JsonPropertyName("city")] public List<PortraitItem>? City { get; set; }
    /// <summary>性别分布</summary>
    [JsonPropertyName("genders")] public List<PortraitItem>? Genders { get; set; }
    /// <summary>平台分布</summary>
    [JsonPropertyName("platforms")] public List<PortraitItem>? Platforms { get; set; }
    /// <summary>设备分布</summary>
    [JsonPropertyName("devices")] public List<PortraitItem>? Devices { get; set; }
    /// <summary>年龄分布</summary>
    [JsonPropertyName("ages")] public List<PortraitItem>? Ages { get; set; }
}

