using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class NotifyAppRequest
{
    [JsonPropertyName("msg_type")]
    public string? MsgType { get; set; }

    [JsonPropertyName("msg_content")]
    public Dictionary<string, object>? MsgContent { get; set; }
}