using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 绑定/解绑物流账号响应
/// </summary>
public sealed class BindAccountResponse : WechatBaseResponse
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public string? DeliveryId { get; init; }
    /// <summary>绑定状态（0绑定中 1已绑定 2解绑中 3已解绑）</summary>
    [JsonPropertyName("bind_status")] public int BindStatus { get; init; }
}