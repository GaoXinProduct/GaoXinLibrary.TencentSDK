using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询license资源包列表响应
/// </summary>
public sealed class GetLicensePkgListResponse : WechatBaseResponse
{
    /// <summary>资源包列表</summary>
    [JsonPropertyName("packages")] public List<LicensePkgItem>? Packages { get; init; }
    /// <summary>总数</summary>
    [JsonPropertyName("total")] public int Total { get; init; }
}

/// <summary>
/// License资源包项
/// </summary>
public sealed class LicensePkgItem
{
    /// <summary>资源包ID</summary>
    [JsonPropertyName("package_id")] public string? PackageId { get; init; }
    /// <summary>资源包名称</summary>
    [JsonPropertyName("name")] public string? Name { get; init; }
    /// <summary>剩余数量</summary>
    [JsonPropertyName("remain")] public int Remain { get; init; }
    /// <summary>总数量</summary>
    [JsonPropertyName("total")] public int Total { get; init; }
    /// <summary>购买时间</summary>
    [JsonPropertyName("buy_time")] public long BuyTime { get; init; }
    /// <summary>过期时间</summary>
    [JsonPropertyName("expire_time")] public long ExpireTime { get; init; }
}