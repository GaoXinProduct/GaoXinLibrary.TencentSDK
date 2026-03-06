using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>查询JS错误详情响应</summary>
public class GetJsErrDetailResponse : WechatBaseResponse
{
    /// <summary>错误总数</summary>
    [JsonPropertyName("totalCount")]  public int TotalCount { get; set; }
    /// <summary>错误详情列表</summary>
    [JsonPropertyName("errList")]     public List<JsErrDetailItem>? ErrList { get; set; }
}

/// <summary>JS错误详情项</summary>
public class JsErrDetailItem
{
    [JsonPropertyName("openid")]       public string? OpenId { get; set; }
    [JsonPropertyName("appversion")]   public string? AppVersion { get; set; }
    [JsonPropertyName("errtime")]      public long ErrTime { get; set; }
    [JsonPropertyName("errmsg")]       public string? ErrMsg { get; set; }
    [JsonPropertyName("errstack")]     public string? ErrStack { get; set; }
    [JsonPropertyName("clientVersion")] public string? ClientVersion { get; set; }
    [JsonPropertyName("sdkVersion")]   public string? SdkVersion { get; set; }
}
