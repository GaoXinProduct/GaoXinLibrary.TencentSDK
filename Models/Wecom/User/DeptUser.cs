using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

public sealed class DeptUser
{
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
    [JsonPropertyName("department")] public int Department { get; set; }
}

