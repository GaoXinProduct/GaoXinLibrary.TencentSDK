
namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>创建收集表请求，也供旧版编辑方法使用。</summary>
public sealed class CollectFormOperationRequest
{
    /// <summary>目标空间 ID。</summary>
    [JsonPropertyName("spaceid")]
    public string? SpaceId { get; set; }

    /// <summary>父目录 ID。位于空间根目录时填写空间 ID。</summary>
    [JsonPropertyName("fatherid")]
    public string? ParentFolderId { get; set; }

    /// <summary>收集表信息</summary>
    [JsonPropertyName("form_info")]
    public CollectFormInfo FormInfo { get; set; } = new();
}
