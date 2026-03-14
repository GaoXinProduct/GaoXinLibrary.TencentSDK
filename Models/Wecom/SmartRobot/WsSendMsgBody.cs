using System.Text.Json;
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// aibot_send_msg 主动推送消息体
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public class WsSendMsgBody
{
    /// <summary>会话 ID（单聊填用户 userid，群聊填群聊 chatid）</summary>
    [JsonPropertyName("chatid")] public string ChatId { get; set; } = string.Empty;

    /// <summary>会话类型：1-单聊；2-群聊；0 或不填-兼容（优先按群聊发送）</summary>
    [JsonPropertyName("chat_type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int ChatType { get; set; }

    /// <summary>消息类型（markdown / template_card / file / image / voice / video）</summary>
    [JsonPropertyName("msgtype")] public string MsgType { get; set; } = string.Empty;

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
