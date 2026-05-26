using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>创建预约直播响应</summary>
public sealed class CreateLivingResponse : WecomBaseResponse
{
    /// <summary>直播ID</summary>
    [JsonPropertyName("livingid")] public string? LivingId { get; set; }
}
