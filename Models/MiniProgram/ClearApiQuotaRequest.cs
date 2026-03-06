using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 重置指定API调用次数请求（POST /cgi-bin/openapi/quota/clear）
/// </summary>
public class ClearApiQuotaRequest
{
    /// <summary>api 的请求地址（如 /cgi-bin/message/custom/send）</summary>
    [JsonPropertyName("cgi_path")] public required string CgiPath { get; set; }
}
