using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

public sealed class GetUserIdByMobileResponse : WecomBaseResponse
{
    [JsonPropertyName("userid")] public string? UserId { get; set; }
}

