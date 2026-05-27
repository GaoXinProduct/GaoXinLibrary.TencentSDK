using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security.Expansion;

public class GetScreenCaptureControlResponse : WecomBaseResponse
{
    [JsonPropertyName("control_type")]
    public int ControlType { get; set; }

    [JsonPropertyName("chatid")]
    public string? ChatId { get; set; }

    [JsonPropertyName("userid")]
    public string? UserId { get; set; }
}