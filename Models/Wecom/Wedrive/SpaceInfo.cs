using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>空间信息</summary>
public class SpaceInfo
{
    /// <summary>空间ID</summary>
    [JsonPropertyName("spaceid")] public string? SpaceId { get; set; }

    /// <summary>空间名称</summary>
    [JsonPropertyName("space_name")] public string? SpaceName { get; set; }

    /// <summary>空间创建者userid</summary>
    [JsonPropertyName("auth_list")] public SpaceAuthList? AuthList { get; set; }
}
