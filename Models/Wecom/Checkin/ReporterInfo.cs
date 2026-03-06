using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>汇报对象信息</summary>
public class ReporterInfo
{
    /// <summary>汇报对象列表</summary>
    [JsonPropertyName("reporters")] public Reporter[]? Reporters { get; set; }

    /// <summary>更新时间</summary>
    [JsonPropertyName("updatetime")] public long? UpdateTime { get; set; }
}

