using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>内容安全检测详情</summary>
public class MsgSecCheckDetail
{
    /// <summary>策略类型</summary>
    [JsonPropertyName("strategy")] public string? Strategy { get; set; }

    /// <summary>错误码（0 无异常）</summary>
    [JsonPropertyName("errcode")] public int ErrCode { get; set; }

    /// <summary>建议（risky/pass/review）</summary>
    [JsonPropertyName("suggest")] public string? Suggest { get; set; }

    /// <summary>命中标签枚举值（100 正常；10001 广告；20001 时政；等）</summary>
    [JsonPropertyName("label")] public int Label { get; set; }

    /// <summary>命中的自定义关键词</summary>
    [JsonPropertyName("keyword")] public string? Keyword { get; set; }

    /// <summary>置信度（0-100）</summary>
    [JsonPropertyName("prob")] public int Prob { get; set; }
}

