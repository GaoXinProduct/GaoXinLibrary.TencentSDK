namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>通过智能机器人回调地址主动回复的消息。</summary>
public sealed class SmartRobotReplyRequest
{
    /// <summary>消息类型，支持 markdown 和 template_card。</summary>
    [JsonPropertyName("msgtype")] public string MsgType { get; set; } = "markdown";

    /// <summary>Markdown 消息内容。</summary>
    [JsonPropertyName("markdown")] public SmartRobotMarkdownReply? Markdown { get; set; }

    /// <summary>模板卡片对象，仅在单聊中支持。</summary>
    [JsonPropertyName("template_card")] public JsonElement? TemplateCard { get; set; }
}

/// <summary>智能机器人回复的 Markdown 内容。</summary>
public sealed class SmartRobotMarkdownReply
{
    /// <summary>UTF-8 文本，最长 20480 字节。</summary>
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;

    /// <summary>可选的消息反馈标识。</summary>
    [JsonPropertyName("feedback")] public SmartRobotReplyFeedback? Feedback { get; set; }
}

/// <summary>智能机器人回复的反馈标识。</summary>
public sealed class SmartRobotReplyFeedback
{
    /// <summary>反馈事件回传的 ID，最长 256 字节。</summary>
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
}
