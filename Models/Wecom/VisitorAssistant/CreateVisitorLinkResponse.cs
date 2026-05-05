using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.VisitorAssistant;

public class CreateVisitorLinkResponse : WecomBaseResponse
{
    [JsonPropertyName("link_id")]
    public string? LinkId { get; set; }
}