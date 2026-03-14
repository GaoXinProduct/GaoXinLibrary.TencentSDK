using System.Text.Json;
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// aibot_respond_welcome_msg 回复欢迎语体
/// <para>收到 enter_chat 事件后 5 秒内回复。</para>
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public class WsRespondWelcomeMsgBody
{
    /// <summary>消息类型（text / markdown / template_card）</summary>
    [JsonPropertyName("msgtype")] public string MsgType { get; set; } = string.Empty;

    /// <summary>文本消息内容</summary>
    [JsonPropertyName("text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonElement? Text { get; set; }

    /// <summary>Markdown 消息内容</summary>
    [JsonPropertyName("markdown")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonElement? Markdown { get; set; }

    /// <summary>模板卡片消息内容</summary>
    [JsonPropertyName("template_card")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonElement? TemplateCard { get; set; }
}
