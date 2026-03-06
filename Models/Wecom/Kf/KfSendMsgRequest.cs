using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>发送消息请求</summary>
public class KfSendMsgRequest
{
    /// <summary>指定发送消息的客服账号 id</summary>
    [JsonPropertyName("open_kfid")] public string OpenKfId { get; set; } = string.Empty;

    /// <summary>指定接收消息的客户 external_userid</summary>
    [JsonPropertyName("touser")] public string ToUser { get; set; } = string.Empty;

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

    /// <summary>指定消息 id（可选，用于去重）</summary>
    [JsonPropertyName("msgid")] public string? MsgId { get; set; }
}

