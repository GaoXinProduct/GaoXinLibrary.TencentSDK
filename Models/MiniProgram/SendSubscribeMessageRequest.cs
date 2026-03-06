using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 发送订阅消息请求（POST /cgi-bin/message/subscribe/send）
/// </summary>
public class SendSubscribeMessageRequest
{
    /// <summary>接收者 OpenId</summary>
    [JsonPropertyName("touser")] public required string ToUser { get; set; }

    /// <summary>订阅消息模板 ID</summary>
    [JsonPropertyName("template_id")] public required string TemplateId { get; set; }

    /// <summary>点击模板消息后跳转的页面（可选）</summary>
    [JsonPropertyName("page")] public string? Page { get; set; }

    /// <summary>
    /// 模板数据，键为模板中的关键词序号（如 thing1, number2 等），
    /// 值为 <see cref="SubscribeMessageDataValue"/>
    /// </summary>
    [JsonPropertyName("data")] public required Dictionary<string, SubscribeMessageDataValue> Data { get; set; }

    /// <summary>跳转小程序类型：developer/trial/formal，默认 formal</summary>
    [JsonPropertyName("miniprogram_state")] public string? MiniProgramState { get; set; }

    /// <summary>进入小程序查看的语言类型：zh_CN/en_US/zh_TW，默认 zh_CN</summary>
    [JsonPropertyName("lang")] public string? Lang { get; set; }
}

