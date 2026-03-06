using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 发送客服消息请求（POST /cgi-bin/message/custom/send）
/// </summary>
public class SendCustomMessageRequest
{
    /// <summary>接收者 OpenId</summary>
    [JsonPropertyName("touser")] public required string ToUser { get; set; }

    /// <summary>消息类型（text/image/link/miniprogrampage）</summary>
    [JsonPropertyName("msgtype")] public required string MsgType { get; set; }

    /// <summary>文本消息内容（msgtype=text 时必填）</summary>
    [JsonPropertyName("text")] public CustomTextContent? Text { get; set; }

    /// <summary>图片消息（msgtype=image 时必填）</summary>
    [JsonPropertyName("image")] public CustomImageContent? Image { get; set; }

    /// <summary>图文链接（msgtype=link 时必填）</summary>
    [JsonPropertyName("link")] public CustomLinkContent? Link { get; set; }

    /// <summary>小程序卡片（msgtype=miniprogrampage 时必填）</summary>
    [JsonPropertyName("miniprogrampage")] public CustomMiniProgramContent? MiniProgramPage { get; set; }
}

