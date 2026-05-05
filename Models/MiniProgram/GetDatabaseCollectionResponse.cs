using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取集合信息响应
/// </summary>
public sealed class GetDatabaseCollectionResponse : WechatBaseResponse
{
    [JsonPropertyName("collections")] public List<CollectionInfo>? Collections { get; init; }
}

/// <summary>
/// 集合信息
/// </summary>
public sealed class CollectionInfo
{
    /// <summary>集合名称</summary>
    [JsonPropertyName("name")] public string? Name { get; init; }
    /// <summary>记录数量</summary>
    [JsonPropertyName("count")] public int Count { get; init; }
}