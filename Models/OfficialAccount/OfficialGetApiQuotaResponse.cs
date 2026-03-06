using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询 openAPI 调用额度响应</summary>
public class OfficialGetApiQuotaResponse : WechatBaseResponse
{
    [JsonPropertyName("quota")] public OfficialApiQuotaInfo? Quota { get; set; }
}

