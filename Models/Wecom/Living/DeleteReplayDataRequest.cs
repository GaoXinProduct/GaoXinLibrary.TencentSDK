using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>删除直播回放请求</summary>
public class DeleteReplayDataRequest
{
    /// <summary>直播 ID</summary>
    [JsonPropertyName("livingid")]
    public string LivingId { get; set; } = string.Empty;
}
