// ═══════════════════════════════════════════════════════════════════════════

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 选用模板请求（POST /wxa/add_template）
/// </summary>
public sealed class AddTemplateRequest
{
    /// <summary>模板标题ID</summary>
    [JsonPropertyName("tid")] public required int TemplateId { get; set; }
    
    /// <summary>关键词ID列表（最多10个）</summary>
    [JsonPropertyName("kid_list")] public required List<int> KidList { get; set; }
    
    /// <summary>场景描述</summary>
    [JsonPropertyName("scene_desc")] public string? SceneDesc { get; set; }
}