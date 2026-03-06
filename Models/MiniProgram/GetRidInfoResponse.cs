using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>查询 rid 信息响应</summary>
public class GetRidInfoResponse : WechatBaseResponse
{
    /// <summary>请求信息</summary>
    [JsonPropertyName("request")] public RidRequestInfo? Request { get; set; }
}

