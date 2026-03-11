using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>空间权限列表</summary>
public class SpaceAuthList
{
    /// <summary>有权限的userid列表</summary>
    [JsonPropertyName("auth_info")] public SpaceAuthInfo[]? AuthInfo { get; set; }
}
