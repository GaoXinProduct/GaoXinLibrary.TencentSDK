// ═══════════════════════════════════════════════════════════════════════════

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取已添加的模板列表响应（GET /wxa/get_template_list）
/// </summary>
public sealed class GetTemplateListResponse : WechatBaseResponse
{
    /// <summary>模板列表</summary>
    [JsonPropertyName("list")] public List<TemplateListItem>? List { get; init; }
}

public sealed class TemplateListItem
{
    /// <summary>模板ID</summary>
    [JsonPropertyName("pri_tmpl_id")] public string? TemplateId { get; init; }
    /// <summary>模板标题</summary>
    [JsonPropertyName("title")] public string? Title { get; init; }
    /// <summary>模板内容</summary>
    [JsonPropertyName("content")] public string? Content { get; init; }
    /// <summary>模板示例</summary>
    [JsonPropertyName("example")] public string? Example { get; init; }
    /// <summary>创建时间（Unix时间戳）</summary>
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
    /// <summary>更新时间（Unix时间戳）</summary>
    [JsonPropertyName("update_time")] public long UpdateTime { get; init; }
}