// ═══════════════════════════════════════════════════════════════════════════

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取模板中的关键词响应
/// </summary>
public sealed class GetPubTemplateKeywordsResponse : WechatBaseResponse
{
    /// <summary>关键词列表</summary>
    [JsonPropertyName("keywords")] public List<PubTemplateKeywordItem>? Keywords { get; init; }
}

public sealed class PubTemplateKeywordItem
{
    /// <summary>关键词ID</summary>
    [JsonPropertyName("kid")] public int Kid { get; init; }
    /// <summary>关键词名称</summary>
    [JsonPropertyName("name")] public string? Name { get; init; }
    /// <summary>关键词内容示例</summary>
    [JsonPropertyName("example")] public string? Example { get; init; }
    /// <summary>关键词规则说明</summary>
    [JsonPropertyName("rule")] public int Rule { get; init; }
}