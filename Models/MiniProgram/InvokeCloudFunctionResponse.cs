using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 触发云函数响应
/// </summary>
public sealed class InvokeCloudFunctionResponse : WechatBaseResponse
{
    /// <summary>云函数返回的结果（JSON字符串）</summary>
    [JsonPropertyName("resp_data")] public string? RespData { get; init; }
    /// <summary>请求ID</summary>
    [JsonPropertyName("request_id")] public string? RequestId { get; init; }
}