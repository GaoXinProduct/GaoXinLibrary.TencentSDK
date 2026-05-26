
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>空间权限列表</summary>
public sealed class SpaceAuthList
{
    /// <summary>有权限的userid列表</summary>
    [JsonPropertyName("auth_info")] public SpaceAuthInfo[]? AuthInfo { get; set; }
}
