using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询门店信息响应</summary>
public sealed class GetPoiResponse : WechatBaseResponse
{
    [JsonPropertyName("business")] public PoiBusiness? Business { get; set; }
}

