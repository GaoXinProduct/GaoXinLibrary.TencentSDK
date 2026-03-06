using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

public class GetUserIdByMobileResponse : WecomBaseResponse
{
    [JsonPropertyName("userid")] public string? UserId { get; set; }
}

