using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取「客户数据」统计请求（企业汇总/接待人员明细通用）</summary>
public class KfStatisticRequest
{
    /// <summary>客服账号 id（非必填，不填则查所有账号）</summary>
    [JsonPropertyName("open_kfid")] public string? OpenKfId { get; set; }

    /// <summary>接待人员 userid（仅接待人员明细需要，非必填）</summary>
    [JsonPropertyName("servicer_userid")] public string? ServicerUserId { get; set; }

    /// <summary>起始日期的时间戳</summary>
    [JsonPropertyName("start_time")] public long StartTime { get; set; }

    /// <summary>结束日期的时间戳</summary>
    [JsonPropertyName("end_time")] public long EndTime { get; set; }
}

