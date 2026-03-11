using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AdvancedAccount;

/// <summary>高级功能账号信息</summary>
public class AdvancedAccountInfo
{
    /// <summary>成员userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>账号类型</summary>
    [JsonPropertyName("type")] public int Type { get; set; }

    /// <summary>过期时间</summary>
    [JsonPropertyName("expire_time")] public long ExpireTime { get; set; }
}
