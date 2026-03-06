using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>画像分布项</summary>
public class PortraitItem
{
    /// <summary>分布 ID / 名称</summary>
    [JsonPropertyName("id")] public int Id { get; set; }
    /// <summary>名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }
    /// <summary>占比值</summary>
    [JsonPropertyName("value")] public double Value { get; set; }
}

