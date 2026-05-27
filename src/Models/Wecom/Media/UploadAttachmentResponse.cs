using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Media;

#region 上传附件资源（客户联系专用）

/// <summary>上传附件资源响应</summary>
public sealed class UploadAttachmentResponse : WecomBaseResponse
{
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
}

#endregion
