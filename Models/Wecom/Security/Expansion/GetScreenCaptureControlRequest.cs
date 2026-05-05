using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security.Expansion;

public class GetScreenCaptureControlRequest
{
    [JsonPropertyName("chatid")]
    public string? ChatId { get; set; }

    [JsonPropertyName("userid")]
    public string? UserId { get; set; }
}