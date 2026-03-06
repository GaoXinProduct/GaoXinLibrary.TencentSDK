using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>发送事件响应消息请求（欢迎语等）</summary>
public class KfSendMsgOnEventRequest
{
    /// <summary>事件响应消息对应的 code</summary>
    [JsonPropertyName("code")] public string Code { get; set; } = string.Empty;

    /// <summary>消息类型</summary>
    [JsonPropertyName("msgtype")] public string MsgType { get; set; } = string.Empty;

    /// <summary>文本消息</summary>
    [JsonPropertyName("text")] public KfMsgText? Text { get; set; }

    /// <summary>图片消息</summary>
    [JsonPropertyName("image")] public KfMsgMedia? Image { get; set; }

    /// <summary>语音消息</summary>
    [JsonPropertyName("voice")] public KfMsgMedia? Voice { get; set; }

    /// <summary>视频消息</summary>
    [JsonPropertyName("video")] public KfMsgMedia? Video { get; set; }

    /// <summary>文件消息</summary>
    [JsonPropertyName("file")] public KfMsgMedia? File { get; set; }

    /// <summary>链接消息</summary>
    [JsonPropertyName("link")] public KfMsgLink? Link { get; set; }

    /// <summary>小程序消息</summary>
    [JsonPropertyName("miniprogram")] public KfMsgMiniProgram? MiniProgram { get; set; }

    /// <summary>菜单消息</summary>
    [JsonPropertyName("msgmenu")] public KfMsgMenu? MsgMenu { get; set; }
}

