using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;

/// <summary>应用推送群聊消息请求</summary>
public class SendGroupChatMessageRequest
{
    /// <summary>群聊唯一标识</summary>
    [JsonPropertyName("chatid")] public string ChatId { get; set; } = string.Empty;

    /// <summary>消息类型，如 text/image/voice/video/file/textcard/news/mpnews/markdown</summary>
    [JsonPropertyName("msgtype")] public string MsgType { get; set; } = string.Empty;

    /// <summary>文本消息内容</summary>
    [JsonPropertyName("text")] public TextContent? Text { get; set; }

    /// <summary>图片消息内容</summary>
    [JsonPropertyName("image")] public MediaContent? Image { get; set; }

    /// <summary>语音消息内容</summary>
    [JsonPropertyName("voice")] public MediaContent? Voice { get; set; }

    /// <summary>视频消息内容</summary>
    [JsonPropertyName("video")] public VideoContent? Video { get; set; }

    /// <summary>文件消息内容</summary>
    [JsonPropertyName("file")] public MediaContent? File { get; set; }

    /// <summary>文本卡片消息内容</summary>
    [JsonPropertyName("textcard")] public TextCardContent? TextCard { get; set; }

    /// <summary>图文消息内容</summary>
    [JsonPropertyName("news")] public NewsContent? News { get; set; }

    /// <summary>mpnews 图文消息内容</summary>
    [JsonPropertyName("mpnews")] public MpNewsContent? MpNews { get; set; }

    /// <summary>markdown 消息内容</summary>
    [JsonPropertyName("markdown")] public MarkdownContent? Markdown { get; set; }

    /// <summary>是否加密传输（0=否, 1=是），默认为0</summary>
    [JsonPropertyName("safe")] public int Safe { get; set; }
}

