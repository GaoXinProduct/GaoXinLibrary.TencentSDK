using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay;

/// <summary>获取账单列表请求（按项目）</summary>
public class GetProjectBillListRequest
{
    /// <summary>项目 ID</summary>
    [JsonPropertyName("projectid")]
    public string ProjectId { get; set; } = string.Empty;

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;

    /// <summary>每页大小</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 100;
}
