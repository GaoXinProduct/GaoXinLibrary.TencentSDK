
namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>创建/修改收集表请求</summary>
public sealed class CollectFormOperationRequest
{
    /// <summary>收集表信息</summary>
    [JsonPropertyName("form_info")]
    public CollectFormInfo FormInfo { get; set; } = new();
}
