using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>草稿列表项</summary>
public class DraftItem
{
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }
    [JsonPropertyName("content")] public DraftContent? Content { get; set; }
    [JsonPropertyName("update_time")] public long UpdateTime { get; set; }
}

