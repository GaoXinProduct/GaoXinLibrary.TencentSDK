using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取所有绑定的物流账号响应
/// </summary>
public sealed class GetAllAccountResponse : WechatBaseResponse
{
    /// <summary>绑定的账号列表</summary>
    [JsonPropertyName("account_list")] public List<BindAccountInfo>? AccountList { get; init; }
}

/// <summary>
/// 绑定账号信息
/// </summary>
public sealed class BindAccountInfo
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public string? DeliveryId { get; init; }
    /// <summary>快递公司名称</summary>
    [JsonPropertyName("delivery_name")] public string? DeliveryName { get; init; }
    /// <summary>绑定状态（1已绑定 2绑定中）</summary>
    [JsonPropertyName("status")] public int Status { get; init; }
    /// <summary>商户ID</summary>
    [JsonPropertyName("mch_id")] public string? MchId { get; init; }
}