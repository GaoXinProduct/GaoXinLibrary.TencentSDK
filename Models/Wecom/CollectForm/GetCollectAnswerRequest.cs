using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>获取收集表答案请求</summary>
public class GetCollectAnswerRequest
{
    /// <summary>收集表 ID</summary>
    [JsonPropertyName("formid")]
    public string FormId { get; set; } = string.Empty;

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;

    /// <summary>每页大小</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 100;
}
