using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 音视频内容安全异步检测响应
/// </summary>
public class MediaCheckAsyncResponse : WechatBaseResponse
{
    /// <summary>任务 ID，用于匹配异步推送结果</summary>
    [JsonPropertyName("trace_id")] public string? TraceId { get; set; }
}

