using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 文本内容安全检测响应
/// </summary>
public class MsgSecCheckResponse : WechatBaseResponse
{
    /// <summary>检测结果详情</summary>
    [JsonPropertyName("detail")] public List<MsgSecCheckDetail>? Detail { get; set; }

    /// <summary>综合结果</summary>
    [JsonPropertyName("result")] public MsgSecCheckResult? Result { get; set; }

    /// <summary>唯一请求标识，标记单次请求</summary>
    [JsonPropertyName("trace_id")] public string? TraceId { get; set; }
}

