using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询 openAPI 调用额度请求（POST /cgi-bin/openapi/quota/get）</summary>
public class OfficialGetApiQuotaRequest
{
    /// <summary>api 的请求地址，如 "/cgi-bin/bindphone/get"</summary>
    [JsonPropertyName("cgi_path")] public required string CgiPath { get; set; }
}

