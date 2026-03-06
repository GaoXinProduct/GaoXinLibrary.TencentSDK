using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取草稿列表响应</summary>
public class BatchGetDraftResponse : WechatBaseResponse
{
    [JsonPropertyName("total_count")] public int TotalCount { get; set; }
    [JsonPropertyName("item_count")] public int ItemCount { get; set; }
    [JsonPropertyName("item")] public List<DraftItem>? Item { get; set; }
}

