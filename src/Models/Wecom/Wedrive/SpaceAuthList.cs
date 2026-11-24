
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>空间权限列表</summary>
public sealed class SpaceAuthList
{
    /// <summary>有权限的成员及部门</summary>
    [JsonPropertyName("auth_info")] public SpaceAuthInfo[]? AuthInfo { get; set; }

    /// <summary>已退出空间的成员 ID</summary>
    [JsonPropertyName("quit_userid")] public string[]? QuitUserIds { get; set; }
}
