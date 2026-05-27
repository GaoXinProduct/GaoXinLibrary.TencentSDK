using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询设备激活详情响应
/// </summary>
public sealed class GetLicenseDeviceInfoResponse : WechatBaseResponse
{
    /// <summary>激活状态</summary>
    [JsonPropertyName("active")] public bool Active { get; init; }
    /// <summary>激活时间</summary>
    [JsonPropertyName("active_time")] public long ActiveTime { get; init; }
    /// <summary>资源包ID</summary>
    [JsonPropertyName("package_id")] public string? PackageId { get; init; }
    /// <summary>过期时间</summary>
    [JsonPropertyName("expire_time")] public long ExpireTime { get; init; }
}