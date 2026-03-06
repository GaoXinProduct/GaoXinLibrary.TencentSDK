using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>内容安全综合结果</summary>
public class MsgSecCheckResult
{
    /// <summary>建议（risky/pass/review）</summary>
    [JsonPropertyName("suggest")] public string? Suggest { get; set; }

    /// <summary>命中标签枚举值</summary>
    [JsonPropertyName("label")] public int Label { get; set; }
}

