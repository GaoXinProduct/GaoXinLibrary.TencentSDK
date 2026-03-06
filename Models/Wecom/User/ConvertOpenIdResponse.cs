using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

public class ConvertOpenIdResponse : WecomBaseResponse
{
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
    [JsonPropertyName("userid")] public string? UserId { get; set; }
}

