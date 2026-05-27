using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

/// <summary>简单成员信息（userid + name）</summary>
public sealed class SimpleUserInfo
{
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
    [JsonPropertyName("name")] public string? Name { get; set; }
}

