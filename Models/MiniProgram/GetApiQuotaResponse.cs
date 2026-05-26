using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>查询接口调用额度响应</summary>
public sealed class GetApiQuotaResponse : WechatBaseResponse
{
    /// <summary>quota 详情</summary>
    [JsonPropertyName("quota")] public ApiQuotaDetail? Quota { get; set; }
}

