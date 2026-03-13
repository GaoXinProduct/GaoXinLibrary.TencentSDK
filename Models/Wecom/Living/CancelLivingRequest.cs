using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>取消预约直播请求</summary>
public class CancelLivingRequest
{
    /// <summary>直播 ID</summary>
    [JsonPropertyName("livingid")]
    public string LivingId { get; set; } = string.Empty;
}
