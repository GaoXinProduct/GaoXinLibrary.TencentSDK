using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 查询接口调用额度请求（POST /cgi-bin/openapi/quota/get）
/// </summary>
public class GetApiQuotaRequest
{
    /// <summary>api 的请求地址（如 /bindcomponent）</summary>
    [JsonPropertyName("cgi_path")] public required string CgiPath { get; set; }
}

