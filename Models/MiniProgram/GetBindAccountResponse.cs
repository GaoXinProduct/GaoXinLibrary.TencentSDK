using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 拉取已绑定账号响应
/// </summary>
public sealed class GetBindAccountResponse : WechatBaseResponse
{
    /// <summary>绑定的账号列表</summary>
    [JsonPropertyName("list")] public List<BindAccountItem>? List { get; init; }
}

/// <summary>
/// 绑定账号项
/// </summary>
public sealed class BindAccountItem
{
    /// <summary>绑定的账号</summary>
    [JsonPropertyName("bind_account")] public string? BindAccount { get; init; }
    /// <summary>账号状态</summary>
    [JsonPropertyName("status")] public int Status { get; init; }
}