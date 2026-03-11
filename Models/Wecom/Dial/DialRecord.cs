using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Dial;

/// <summary>公费电话拨打记录</summary>
public class DialRecord
{
    /// <summary>拨打的userid</summary>
    [JsonPropertyName("caller")] public DialCaller? Caller { get; set; }

    /// <summary>被拨打的号码列表</summary>
    [JsonPropertyName("callee")] public DialCallee[]? Callee { get; set; }

    /// <summary>拨出时间（Unix时间戳）</summary>
    [JsonPropertyName("call_time")] public long CallTime { get; set; }

    /// <summary>通话时长（秒）</summary>
    [JsonPropertyName("total_duration")] public int TotalDuration { get; set; }
}
