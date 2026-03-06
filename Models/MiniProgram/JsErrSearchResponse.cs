using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>实时日志查询响应</summary>
public class JsErrSearchResponse : WechatBaseResponse
{
    /// <summary>日志列表</summary>
    [JsonPropertyName("data")] public List<JsErrItem>? Data { get; set; }
    /// <summary>总条数</summary>
    [JsonPropertyName("totalcount")] public int TotalCount { get; set; }
}

