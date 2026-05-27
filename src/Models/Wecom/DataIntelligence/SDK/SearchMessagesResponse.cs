using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class SearchMessagesResponse : WecomBaseResponse
{
    [JsonPropertyName("message_list")]
    public MessageInfo[]? MessageList { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}

public class MessageInfo
{
    [JsonPropertyName("msg_id")]
    public string? MsgId { get; set; }

    [JsonPropertyName("msg_time")]
    public long MsgTime { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }
}