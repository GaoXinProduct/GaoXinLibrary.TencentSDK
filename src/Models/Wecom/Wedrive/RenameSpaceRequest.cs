
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>重命名空间请求</summary>
public sealed class RenameSpaceRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public string SpaceId { get; set; } = string.Empty;

    /// <summary>新空间名称</summary>
    [JsonPropertyName("space_name")]
    public string SpaceName { get; set; } = string.Empty;
}
