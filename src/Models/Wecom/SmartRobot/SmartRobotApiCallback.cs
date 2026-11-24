namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// 解密后的智能机器人 API 回调消息或事件。参考
/// <see href="https://developer.work.weixin.qq.com/document/path/100719"/> 和
/// <see href="https://developer.work.weixin.qq.com/document/path/101027"/>。
/// </summary>
public sealed class SmartRobotApiCallback
{
    /// <summary>回调消息 ID，可用于排重。</summary>
    [JsonPropertyName("msgid")] public string? MsgId { get; set; }

    /// <summary>触发回调的智能机器人 ID。</summary>
    [JsonPropertyName("aibotid")] public string? BotId { get; set; }

    /// <summary>群聊 ID，单聊可省略。</summary>
    [JsonPropertyName("chatid")] public string? ChatId { get; set; }

    /// <summary>会话类型，single 为单聊，group 为群聊。</summary>
    [JsonPropertyName("chattype")] public string? ChatType { get; set; }

    /// <summary>消息发送者或事件触发者。</summary>
    [JsonPropertyName("from")] public WsMsgFrom? From { get; set; }

    /// <summary>消息类型，事件回调为 event。</summary>
    [JsonPropertyName("msgtype")] public string? MsgType { get; set; }

    /// <summary>仅可使用一次的临时主动回复地址。请勿记录到日志。</summary>
    [JsonPropertyName("response_url")] public string? ResponseUrl { get; set; }

    /// <summary>按消息类型提供的其他字段，包括 text、mixed 或 event。</summary>
    [JsonExtensionData] public Dictionary<string, JsonElement>? Payload { get; set; }
}
