using System.Text.Json;
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// aibot_respond_msg 回复消息体（支持流式消息）
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public class WsRespondMsgBody
{
    /// <summary>消息类型（stream / markdown / template_card / file / image / voice / video）</summary>
    [JsonPropertyName("msgtype")] public string MsgType { get; set; } = string.Empty;

    /// <summary>流式消息内容（msgtype=stream 时使用）</summary>
    [JsonPropertyName("stream")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public WsStreamInfo? Stream { get; set; }

    /// <summary>Markdown 消息内容</summary>
    [JsonPropertyName("markdown")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonElement? Markdown { get; set; }

    /// <summary>模板卡片消息内容</summary>
    [JsonPropertyName("template_card")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonElement? TemplateCard { get; set; }

    /// <summary>文件消息内容</summary>
    [JsonPropertyName("file")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonElement? File { get; set; }

    /// <summary>图片消息内容</summary>
    [JsonPropertyName("image")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonElement? Image { get; set; }

    /// <summary>语音消息内容</summary>
    [JsonPropertyName("voice")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonElement? Voice { get; set; }

    /// <summary>视频消息内容</summary>
    [JsonPropertyName("video")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonElement? Video { get; set; }
}
