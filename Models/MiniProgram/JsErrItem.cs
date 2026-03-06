using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>JS 错误项</summary>
public class JsErrItem
{
    /// <summary>错误信息</summary>
    [JsonPropertyName("errorMsg")] public string? ErrorMsg { get; set; }
    /// <summary>错误堆栈</summary>
    [JsonPropertyName("errorStack")] public string? ErrorStack { get; set; }
    /// <summary>错误次数</summary>
    [JsonPropertyName("count")] public int Count { get; set; }
}

