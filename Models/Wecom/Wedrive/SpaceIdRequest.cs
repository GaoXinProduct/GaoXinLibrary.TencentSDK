using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>解散空间/获取空间信息请求</summary>
public class SpaceIdRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public string SpaceId { get; set; } = string.Empty;
}
