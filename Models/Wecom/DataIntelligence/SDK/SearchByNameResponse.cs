using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class SearchByNameResponse : WecomBaseResponse
{
    [JsonPropertyName("chat_list")]
    public ChatBasicInfo[]? ChatList { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}

public class ChatBasicInfo
{
    [JsonPropertyName("chat_id")]
    public string? ChatId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }
}