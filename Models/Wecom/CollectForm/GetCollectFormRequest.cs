
namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>获取收集表请求</summary>
public sealed class GetCollectFormRequest
{
    /// <summary>收集表 ID</summary>
    [JsonPropertyName("formid")]
    public string FormId { get; set; } = string.Empty;
}
