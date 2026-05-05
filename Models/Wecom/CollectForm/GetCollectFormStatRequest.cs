using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>获取收集表统计信息请求</summary>
public class GetCollectFormStatRequest
{
    /// <summary>收集表 ID</summary>
    [JsonPropertyName("formid")]
    public string FormId { get; set; } = string.Empty;
}
