using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 发送设备消息请求（POST /cgi-bin/message/device/subscribe/send）
/// </summary>
public class SendDeviceMessageRequest
{
    /// <summary>接收者 OpenId</summary>
    [JsonPropertyName("to_openid")] public required string ToOpenId { get; set; }
    /// <summary>设备型号 ID（modelId 需登记）</summary>
    [JsonPropertyName("model_id")] public required string ModelId { get; set; }
    /// <summary>设备序列号</summary>
    [JsonPropertyName("sn")] public required string Sn { get; set; }
    /// <summary>模板 ID</summary>
    [JsonPropertyName("template_id")] public required string TemplateId { get; set; }
    /// <summary>点击后跳转的小程序页面</summary>
    [JsonPropertyName("page")] public string? Page { get; set; }
    /// <summary>跳转小程序类型</summary>
    [JsonPropertyName("miniprogram_state")] public string? MiniProgramState { get; set; }
    /// <summary>模板数据</summary>
    [JsonPropertyName("data")] public required Dictionary<string, SubscribeMessageDataValue> Data { get; set; }
}

