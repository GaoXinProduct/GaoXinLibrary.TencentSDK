using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.Expansion;

public class GetPermitUserListRequest
{
    [JsonPropertyName("chat_id")]
    public string? ChatId { get; set; }

    [JsonPropertyName("room_name")]
    public string? RoomName { get; set; }

    [JsonPropertyName("begin_time")]
    public long? BeginTime { get; set; }

    [JsonPropertyName("end_time")]
    public long? EndTime { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 100;

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}