using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class GetChatDataResponse : WecomBaseResponse
{
    [JsonPropertyName("chat_data")]
    public ChatData? ChatData { get; set; }
}

public class ChatData
{
    [JsonPropertyName("msg_id")]
    public string? MsgId { get; set; }

    [JsonPropertyName("action")]
    public string? Action { get; set; }

    [JsonPropertyName("from")]
    public string? From { get; set; }

    [JsonPropertyName("msg_list")]
    public MsgItem[]? MsgList { get; set; }
}

public class MsgItem
{
    [JsonPropertyName("msgid")]
    public string? MsgId { get; set; }

    [JsonPropertyName("action")]
    public string? Action { get; set; }

    [JsonPropertyName("from")]
    public string? From { get; set; }

    [JsonPropertyName("tolist")]
    public string[]? ToList { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("msgtime")]
    public long MsgTime { get; set; }
}