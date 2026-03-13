using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay;

/// <summary>获取账单列表请求（按时间范围）</summary>
public class GetBillListRequest
{
    /// <summary>起始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("begin_time")]
    public long BeginTime { get; set; }

    /// <summary>结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    /// <summary>收款人 userid</summary>
    [JsonPropertyName("payee_userid")]
    public string? PayeeUserId { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;

    /// <summary>每页大小</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 100;
}
