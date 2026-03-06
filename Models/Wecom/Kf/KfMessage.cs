using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>客服消息</summary>
public class KfMessage
{
    /// <summary>消息 id</summary>
    [JsonPropertyName("msgid")] public string? MsgId { get; set; }

    /// <summary>客服账号 id</summary>
    [JsonPropertyName("open_kfid")] public string? OpenKfId { get; set; }

    /// <summary>微信客户的 external_userid</summary>
    [JsonPropertyName("external_userid")] public string? ExternalUserId { get; set; }

    /// <summary>消息发送时间</summary>
    [JsonPropertyName("send_time")] public long SendTime { get; set; }

    /// <summary>消息来源：3-微信客户发送 4-系统推送 5-接待人员发送</summary>
    [JsonPropertyName("origin")] public int Origin { get; set; }

    /// <summary>接待人员 userid</summary>
    [JsonPropertyName("servicer_userid")] public string? ServicerUserId { get; set; }

    /// <summary>消息类型</summary>
    [JsonPropertyName("msgtype")] public string? MsgType { get; set; }

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

    /// <summary>位置消息</summary>
    [JsonPropertyName("location")] public KfMsgLocation? Location { get; set; }

    /// <summary>链接消息</summary>
    [JsonPropertyName("link")] public KfMsgLink? Link { get; set; }

    /// <summary>名片消息</summary>
    [JsonPropertyName("business_card")] public KfMsgBusinessCard? BusinessCard { get; set; }

    /// <summary>小程序消息</summary>
    [JsonPropertyName("miniprogram")] public KfMsgMiniProgram? MiniProgram { get; set; }

    /// <summary>事件消息</summary>
    [JsonPropertyName("event")] public KfMsgEvent? Event { get; set; }
}

