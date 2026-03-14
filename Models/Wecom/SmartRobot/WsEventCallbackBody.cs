using System.Text.Json;
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// aibot_event_callback 事件回调体
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public class WsEventCallbackBody
{
    /// <summary>本次回调的唯一性标志，用于事件排重</summary>
    [JsonPropertyName("msgid")] public string MsgId { get; set; } = string.Empty;

    /// <summary>事件产生的时间戳</summary>
    [JsonPropertyName("create_time")] public long CreateTime { get; set; }

    /// <summary>智能机器人 BotID</summary>
    [JsonPropertyName("aibotid")] public string AiBotId { get; set; } = string.Empty;

    /// <summary>会话 ID，仅群聊类型时返回</summary>
    [JsonPropertyName("chatid")] public string? ChatId { get; set; }

    /// <summary>会话类型，single 单聊 / group 群聊</summary>
    [JsonPropertyName("chattype")] public string? ChatType { get; set; }

    /// <summary>事件触发者</summary>
    [JsonPropertyName("from")] public WsMsgFrom? From { get; set; }

    /// <summary>消息类型，事件回调固定为 event</summary>
    [JsonPropertyName("msgtype")] public string MsgType { get; set; } = string.Empty;

    /// <summary>事件详情</summary>
    [JsonPropertyName("event")] public WsEventInfo? Event { get; set; }
}
