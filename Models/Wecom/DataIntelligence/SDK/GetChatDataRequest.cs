using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class GetChatDataRequest
{
    [JsonPropertyName("msg_id")]
    public string? MsgId { get; set; }

    [JsonPropertyName("seq")]
    public long Seq { get; set; }
}