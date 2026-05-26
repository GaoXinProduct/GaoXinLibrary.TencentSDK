using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Media;

/// <summary>上传临时素材响应</summary>
public sealed class UploadMediaResponse : WecomBaseResponse
{
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
}

