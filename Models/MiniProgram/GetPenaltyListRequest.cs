using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取小程序交易体验分违规记录请求（POST /wxa/guarantee/get_penalty_list）
/// </summary>
public sealed class GetPenaltyListRequest
{
    /// <summary>开始日期（yyyyMMdd）</summary>
    [JsonPropertyName("begin_date")] public required string BeginDate { get; set; }
    /// <summary>结束日期（yyyyMMdd）</summary>
    [JsonPropertyName("end_date")] public required string EndDate { get; set; }
    /// <summary>分页大小</summary>
    [JsonPropertyName("limit")] public int Limit { get; set; } = 10;
    /// <summary>分页起始位置</summary>
    [JsonPropertyName("offset")] public int Offset { get; set; } = 0;
}
