using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class SearchMessagesRequest
{
    [JsonPropertyName("chat_id")]
    public string? ChatId { get; set; }

    [JsonPropertyName("keyword")]
    public string? Keyword { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 10;

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    [JsonPropertyName("begin_time")]
    public long? BeginTime { get; set; }

    [JsonPropertyName("end_time")]
    public long? EndTime { get; set; }
}