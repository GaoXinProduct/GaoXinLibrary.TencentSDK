using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>创建空间请求</summary>
public class CreateSpaceRequest
{
    /// <summary>空间名称</summary>
    [JsonPropertyName("space_name")]
    public string SpaceName { get; set; } = string.Empty;

    /// <summary>空间管理员权限信息</summary>
    [JsonPropertyName("auth_info")]
    public SpaceAuthItem[] AuthInfo { get; set; } = [];
}
