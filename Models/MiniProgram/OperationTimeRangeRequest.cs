using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取访问来源 / 获取客户端版本 公共请求体（POST）
/// </summary>
public class OperationTimeRangeRequest
{
    /// <summary>开始时间戳（Unix 秒）</summary>
    [JsonPropertyName("startTime")] public long StartTime { get; set; }
    /// <summary>结束时间戳（Unix 秒）</summary>
    [JsonPropertyName("endTime")] public long EndTime { get; set; }
}
