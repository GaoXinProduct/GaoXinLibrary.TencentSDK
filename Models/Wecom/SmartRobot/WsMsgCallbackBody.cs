using System.Text.Json;
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// aibot_msg_callback 消息回调体
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public class WsMsgCallbackBody
{
    /// <summary>本次回调的唯一性标志，用于事件排重</summary>
    [JsonPropertyName("msgid")] public string MsgId { get; set; } = string.Empty;

    /// <summary>智能机器人 BotID</summary>
    [JsonPropertyName("aibotid")] public string AiBotId { get; set; } = string.Empty;

    /// <summary>会话 ID，仅群聊类型时返回</summary>
    [JsonPropertyName("chatid")] public string? ChatId { get; set; }

    /// <summary>会话类型，single 单聊 / group 群聊</summary>
    [JsonPropertyName("chattype")] public string? ChatType { get; set; }

    /// <summary>消息发送者</summary>
    [JsonPropertyName("from")] public WsMsgFrom? From { get; set; }

    /// <summary>消息类型（text / image / mixed / voice / file / video）</summary>
    [JsonPropertyName("msgtype")] public string MsgType { get; set; } = string.Empty;

    /// <summary>文本消息内容</summary>
    [JsonPropertyName("text")] public JsonElement? Text { get; set; }

    /// <summary>图片消息内容（含 url 和 aeskey）</summary>
    [JsonPropertyName("image")] public JsonElement? Image { get; set; }

    /// <summary>语音消息内容</summary>
    [JsonPropertyName("voice")] public JsonElement? Voice { get; set; }

    /// <summary>视频消息内容（含 url 和 aeskey）</summary>
    [JsonPropertyName("video")] public JsonElement? Video { get; set; }

    /// <summary>文件消息内容（含 url 和 aeskey）</summary>
    [JsonPropertyName("file")] public JsonElement? File { get; set; }

    /// <summary>图文混排消息内容</summary>
    [JsonPropertyName("mixed")] public JsonElement? Mixed { get; set; }

    /// <summary>
    /// 文档工具调用列表（msgtype 为 tool_calls 时使用）
    /// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101468"/></para>
    /// </summary>
    [JsonPropertyName("tool_calls")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DocToolCallInfo[]? ToolCalls { get; set; }
}
