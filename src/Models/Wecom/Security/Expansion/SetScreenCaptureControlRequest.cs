using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security.Expansion;

public class SetScreenCaptureControlRequest
{
    [JsonPropertyName("control_type")]
    public int ControlType { get; set; }

    [JsonPropertyName("chatid")]
    public string? ChatId { get; set; }

    [JsonPropertyName("userid")]
    public string? UserId { get; set; }
}