using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>获取跳转小程序商城的直播观众信息请求</summary>
public record GetLivingJumpInfoRequest
{
    /// <summary>直播 ID</summary>
    [JsonPropertyName("livingid")]
    public string LivingId { get; init; } = string.Empty;
}