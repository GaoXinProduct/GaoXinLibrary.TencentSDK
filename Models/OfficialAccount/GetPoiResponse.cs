using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询门店信息响应</summary>
public class GetPoiResponse : WechatBaseResponse
{
    [JsonPropertyName("business")] public PoiBusiness? Business { get; set; }
}

