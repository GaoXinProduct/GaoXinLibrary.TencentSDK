using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>空间权限项</summary>
public class SpaceAuthItem
{
    /// <summary>权限类型，1-管理员</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; } = 1;

    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;
}
