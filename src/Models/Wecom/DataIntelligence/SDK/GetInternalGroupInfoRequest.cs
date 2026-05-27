using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class GetInternalGroupInfoRequest
{
    [JsonPropertyName("room_id")]
    public string? RoomId { get; set; }
}