using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询错误列表请求（POST /wxaapi/log/jserr_list）
/// </summary>
public class JsErrSearchRequest
{
    /// <summary>错误信息关键词（可选）</summary>
    [JsonPropertyName("errmsgKeyword")] public string? ErrMsgKeyword { get; set; }
    /// <summary>错误类型（"0" 全部；"1" JS 错误；"2" API 错误；"3" 网络错误）</summary>
    [JsonPropertyName("errType")] public string ErrType { get; set; } = "1";
    /// <summary>客户端版本（可选）</summary>
    [JsonPropertyName("clientVersion")] public string? ClientVersion { get; set; }
    /// <summary>开始时间戳（秒）</summary>
    [JsonPropertyName("startTime")] public long StartTime { get; set; }
    /// <summary>结束时间戳（秒）</summary>
    [JsonPropertyName("endTime")] public long EndTime { get; set; }
    /// <summary>排序依据（"uv" 按用户数；"pv" 按发生次数）</summary>
    [JsonPropertyName("orderby")] public string OrderBy { get; set; } = "pv";
    /// <summary>排序方式（"1" 升序；"2" 降序）</summary>
    [JsonPropertyName("desc")] public string Desc { get; set; } = "2";
    /// <summary>分页起始</summary>
    [JsonPropertyName("start")] public int Start { get; set; }
    /// <summary>每页条数（最大 100）</summary>
    [JsonPropertyName("limit")] public int Limit { get; set; } = 20;
}

