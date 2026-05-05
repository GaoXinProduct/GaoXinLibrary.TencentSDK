// ═══════════════════════════════════════════════════════════════════════════

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取类目响应（GET /wxa/get_category）
/// </summary>
public sealed class GetCategoryResponse : WechatBaseResponse
{
    /// <summary>类目列表</summary>
    [JsonPropertyName("data")] public List<CategoryItem>? Data { get; init; }
}

public sealed class CategoryItem
{
    /// <summary>类目ID</summary>
    [JsonPropertyName("id")] public int Id { get; init; }
    /// <summary>类目名称</summary>
    [JsonPropertyName("name")] public string? Name { get; init; }
    /// <summary>父类目ID</summary>
    [JsonPropertyName("father_id")] public int FatherId { get; init; }
    /// <summary>层级</summary>
    [JsonPropertyName("level")] public int Level { get; init; }
}