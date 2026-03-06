using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

/// <summary>解密后的消息明文</summary>
public class DecryptedChatMessage
{
    /// <summary>消息 id</summary>
    [JsonPropertyName("msgid")] public string? MsgId { get; set; }

    /// <summary>消息动作：send-发送 recall-撤回 switch-切换企业日志</summary>
    [JsonPropertyName("action")] public string? Action { get; set; }

    /// <summary>消息发送方 userid/external_userid</summary>
    [JsonPropertyName("from")] public string? From { get; set; }

    /// <summary>单聊接收方列表</summary>
    [JsonPropertyName("tolist")] public string[]? ToList { get; set; }

    /// <summary>群聊消息的群 id</summary>
    [JsonPropertyName("roomid")] public string? RoomId { get; set; }

    /// <summary>消息发送时间（时间戳）</summary>
    [JsonPropertyName("msgtime")] public long MsgTime { get; set; }

    /// <summary>消息类型</summary>
    [JsonPropertyName("msgtype")] public string? MsgType { get; set; }

    /// <summary>文本消息</summary>
    [JsonPropertyName("text")] public MsgAuditText? Text { get; set; }

    /// <summary>图片消息</summary>
    [JsonPropertyName("image")] public MsgAuditMedia? Image { get; set; }

    /// <summary>语音消息</summary>
    [JsonPropertyName("voice")] public MsgAuditMedia? Voice { get; set; }

    /// <summary>视频消息</summary>
    [JsonPropertyName("video")] public MsgAuditMedia? Video { get; set; }

    /// <summary>文件消息</summary>
    [JsonPropertyName("file")] public MsgAuditMedia? File { get; set; }

    /// <summary>撤回消息信息</summary>
    [JsonPropertyName("revoke")] public MsgAuditRevoke? Revoke { get; set; }
}

