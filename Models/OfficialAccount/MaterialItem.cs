using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>素材列表项</summary>
public class MaterialItem
{
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("update_time")] public long UpdateTime { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
}

