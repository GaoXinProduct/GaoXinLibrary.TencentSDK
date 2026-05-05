// ═══════════════════════════════════════════════════════════════════════════

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取类目下的公共模板响应
/// </summary>
public sealed class GetPubTemplateTitlesResponse : WechatBaseResponse
{
    /// <summary>模板标题列表</summary>
    [JsonPropertyName("list")] public List<PubTemplateTitleItem>? List { get; init; }
    /// <summary>总数</summary>
    [JsonPropertyName("count")] public int Count { get; init; }
}

public sealed class PubTemplateTitleItem
{
    /// <summary>模板标题ID</summary>
    [JsonPropertyName("tid")] public int Tid { get; init; }
    /// <summary>模板标题</summary>
    [JsonPropertyName("title")] public string? Title { get; init; }
    /// <summary>模板关键词数量</summary>
    [JsonPropertyName("keyword_count")] public int KeywordCount { get; init; }
}