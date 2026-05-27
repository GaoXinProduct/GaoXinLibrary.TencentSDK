using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.VisitorAssistant;

public class GetVisitorLinkResponse : WecomBaseResponse
{
    [JsonPropertyName("link")]
    public VisitorLinkInfo? Link { get; set; }

    [JsonPropertyName("range")]
    public VisitorLinkRange? Range { get; set; }

    [JsonPropertyName("priority_option")]
    public PriorityOption? PriorityOption { get; set; }
}